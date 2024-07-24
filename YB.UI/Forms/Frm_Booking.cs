using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using YB.Business.Abstractions;
using YB.Business.DependicyInjection.AutoFac;
using YB.Entities.Models;

namespace YB.UI.Forms
{
    public partial class Frm_Booking : Form
    {
        private readonly IGuestService guestService;
        private readonly IBookingService bookingService;
        private readonly IHotelService hotelService;
        private readonly IRoomService roomService;
        private readonly IRoomTypeService roomTypeService;

        public Frm_Booking()
        {
            InitializeComponent();
            hotelService = InstanceFactory.GetInstance<IHotelService>();
            guestService = InstanceFactory.GetInstance<IGuestService>();
            bookingService = InstanceFactory.GetInstance<IBookingService>();
            roomService = InstanceFactory.GetInstance<IRoomService>();
            roomTypeService = InstanceFactory.GetInstance<IRoomTypeService>();
        }

        private void Frm_Booking_Load(object sender, EventArgs e)
        {

            lstGuest.Items.Add("a");
            lstGuest.Items.Add("b");
            lstGuest.Items.Add("c");
            lstGuest.Items.Add("d");


            nmrGuest.Minimum = 1;
            nmrGuest.Maximum = 4;
            grpMusteri.Visible = false;
            FillHotelList();
        }

        private void FillRoomType(Guid selectedHotelID)
        {
            var data = roomTypeService.GetAllRoomTypeWithHotel(selectedHotelID).ToList();
            cmbRoomType.DataSource = null;
            cmbRoomType.DataSource = data);
            cmbRoomType.DisplayMember = "Name";
            cmbRoomType.ValueMember = "ID";
        }

        private void FillHotelList()
        {
            lstHotelList.DataSource = null;
            lstHotelList.DataSource = hotelService.GetAll().ToList();
            lstHotelList.DisplayMember = "Name";
            lstHotelList.ValueMember = "ID";
        }

        List<Guest> guest = new List<Guest>();
        int maxindex = 0;
        int nowindex = 0;

        private void nmrGuest_ValueChanged(object sender, EventArgs e)
        {
            if (nmrGuest.Value != 0)
            {
                grpMusteri.Visible = true;
            }
            maxindex = Convert.ToInt32(nmrGuest.Value);
        }

        private void btnGuestSave_Click(object sender, EventArgs e)
        {
            try
            {
                guest[nowindex] = new Guest
                {
                    Address = rtxtAdress.Text,
                    DateOfBirth = DateOnly.FromDateTime(dtpBirthDate.Value),
                    Email = txtMusteriEmail.Text,
                    FirstName = txtMusteriAd.Text,
                    LastName = txtMusteriSoyad.Text,
                    Phone = mskPhone.Text,
                    TC = mskTC.Text,
                };
                guestService.Add(guest[nowindex]);
                nowindex++;
                if (nowindex == maxindex + 1) { grpMusteri.Visible = false; }

            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }
        }

        private void txtHotelFiltre_TextChanged(object sender, EventArgs e)
        {
            string searchText = txtHotelFiltre.Text.ToLower();

            if (!string.IsNullOrEmpty(searchText) && searchText.Length >= 3)
            {
                var pList = hotelService.GetAll().Where(p => p.Name.ToLower().Contains(searchText));

                lstHotelList.ValueMember = "Id";
                lstHotelList.DisplayMember = "ProductName";
                lstHotelList.DataSource = pList.ToList();
            }
            else if (searchText.Length == 0)
            {
                FillHotelList();
            }
        }

        private void lstHotelList_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void lstHotelList_DoubleClick(object sender, EventArgs e)
        {
            FillRoomType(Guid.Parse(lstHotelList.SelectedValue.ToString()));
        }

        private void label11_Click(object sender, EventArgs e)
        {

        }
    }
}
