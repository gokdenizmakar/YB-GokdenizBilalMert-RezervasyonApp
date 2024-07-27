using System.Data;
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

            //Dependicy Injection atamaları:
            hotelService = InstanceFactory.GetInstance<IHotelService>();
            guestService = InstanceFactory.GetInstance<IGuestService>();
            bookingService = InstanceFactory.GetInstance<IBookingService>();
            roomService = InstanceFactory.GetInstance<IRoomService>();
            roomTypeService = InstanceFactory.GetInstance<IRoomTypeService>();
        }

        private void Frm_Booking_Load(object sender, EventArgs e)
        {
            //Oda tipi validasyonu için gerekli.
            cmbRoomType.DataSource = null;

            //tarih seçim ayarları
            dtpCheckOut.MinDate = dtpCheckIn.Value;
            dtpCheckIn.MinDate = DateTime.Now;

            //kişi seçim ayarları
            nmrGuest.Minimum = 0;
            nmrGuest.Maximum = 4;
            grpMusteri.Enabled = false;

            //Hotel listesini doldur
            FillHotelList();

            FillDataGrid();
        }

        private void FillDataGrid()
        {
            dgwBooking.DataSource = null;
            dgwBooking.DataSource = bookingService.GetAllBookingAllDetail();
        }

        //Hotel Listesini Doldur.
        private void FillHotelList()
        {
            try
            {
                lstHotelList.DataSource = null;
                lstHotelList.DataSource = hotelService.GetAll().ToList();
                lstHotelList.DisplayMember = "Name";
                lstHotelList.ValueMember = "ID";
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }
        //işlem gören misafirler:
        List<Guest> guest = new List<Guest>();
        int maxindex = 0;
        int nowindex = 0;

        //Secilen hotelin idsi:
        Guid seciliHotelid = default(Guid);


        private void nmrGuest_ValueChanged(object sender, EventArgs e)
        {
            try
            {

                // Misafir sayısının sıfırdan büyük ve hotel seçilmediği durumda
                if (nmrGuest.Value > 0 && seciliHotelid == default(Guid))
                {
                    if (!boolupdateBooking)
                    {
                        // Misafir sayısını sıfırla ve grup panelini devre dışı bırak
                        nmrGuest.Value = 0;
                        grpMusteri.Enabled = false;
                        ClearGuestGroup();
                        throw new Exception("Lütfen hotel seçiniz!");
                    }
                }

                // Oda ve oda türlerini doldur
                FillRoomAndRoomType();

                // Oda seçilmemişse grup panelini devre dışı bırak ve temizle
                if (cmbRoom.SelectedValue == null)
                {
                    grpMusteri.Enabled = false;
                    ClearGuestGroup();
                }

                // Misafir sayısını kontrol et
                int newGuestCount = Convert.ToInt32(nmrGuest.Value);
                int currentGuestCount = lstGuest.Items.Count;

                if (currentGuestCount > newGuestCount)
                {
                    // Misafir sayısı mevcut olandan fazla olamaz
                    nmrGuest.Value = maxindex;
                    grpMusteri.Enabled = false;
                    ClearGuestGroup();
                    throw new Exception("Kayıtlı misafir sayısı, belirtilen misafir sayısından fazla olamaz! Lütfen misafir siliniz!");
                }
                else if (currentGuestCount == newGuestCount)
                {
                    // Misafir sayısı eşitse, paneli devre dışı bırak ve temizle
                    maxindex = newGuestCount;
                    grpMusteri.Enabled = false;
                    ClearGuestGroup();
                }
                else
                {
                    // Misafir sayısı arttıysa, paneli etkinleştir ve veriyi yenile
                    maxindex = newGuestCount;
                    grpMusteri.Enabled = true;
                    lstGuest.DataSource = null;
                    lstGuest.ValueMember = "ID";
                    lstGuest.DisplayMember = "FullName";
                    lstGuest.DataSource = guest;
                }
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }
        }
        void FillRoomAndRoomType()
        {
            try
            {
                if (nmrGuest.Value > 0 && seciliHotelid != default(Guid))
                {
                    var uygunRooms = bookingService.GetRoomByVisible((byte)nmrGuest.Value, DateOnly.FromDateTime(dtpCheckIn.Value), DateOnly.FromDateTime(dtpCheckOut.Value), seciliHotelid).ToList();
                    if (uygunRooms.Count == 0)
                    {
                        cmbRoom.Text = "";
                        cmbRoomType.Text = "";
                        throw new Exception("Uygun oda bulunamadı!");
                    }
                    cmbRoomType.DisplayMember = "Name";
                    cmbRoomType.ValueMember = "RoomTypeID";
                    cmbRoomType.DataSource = uygunRooms;
                    //cmbRoomType.SelectedIndex = 1;
                }
                else
                {
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        private void btnGuestSave_Click(object sender, EventArgs e)
        {
            try
            {
                if (selectedindex != -1)
                {
                    Guid guncellemeidsi = guest[selectedindex].ID;
                    guest[selectedindex] = new Guest
                    {
                        ID = guncellemeidsi,
                        Address = rtxtAdress.Text,
                        DateOfBirth = DateOnly.FromDateTime(dtpBirthDate.Value),
                        Email = txtMusteriEmail.Text,
                        FirstName = txtMusteriAd.Text,
                        LastName = txtMusteriSoyad.Text,
                        Phone = mskPhone.Text,
                        TC = mskTC.Text
                    };
                    //lstGuest.Items[selectedindex] = guest[selectedindex];
                    lstGuest.SelectedIndex = -1;
                    selectedindex = -1;
                    grpBooking.Enabled = true;
                    btnBookingUpdate.Enabled = true;
                    btnBookingDelete.Enabled = true;
                    btnGuestUpdate.Enabled = true;
                    btnGuestDelete.Enabled = true;
                    updatingGuest = null;
                    lstGuest.DataSource = null;
                    lstGuest.ValueMember = "ID";
                    lstGuest.DisplayMember = "FullName";
                    lstGuest.DataSource = guest;
                    if (nmrGuest.Value == lstGuest.Items.Count)
                    {
                        grpMusteri.Enabled = false;
                        ClearGuestGroup();
                    }

                }
                else
                {
                    while (guest.Count <= nowindex)
                    {
                        guest.Add(new Guest());
                    }

                    guest[nowindex] = new Guest
                    {
                        ID = Guid.NewGuid(),
                        Address = rtxtAdress.Text,
                        DateOfBirth = DateOnly.FromDateTime(dtpBirthDate.Value),
                        Email = txtMusteriEmail.Text,
                        FirstName = txtMusteriAd.Text,
                        LastName = txtMusteriSoyad.Text,
                        Phone = mskPhone.Text,
                        TC = mskTC.Text,
                    };
                    lstGuest.DataSource = null;
                    lstGuest.ValueMember = "ID";
                    lstGuest.DisplayMember = "FullName";
                    lstGuest.DataSource = guest;
                    //lstGuest.Items.Add(guest[nowindex]);
                    nowindex++;
                    if (nowindex == maxindex || nmrGuest.Value == lstGuest.Items.Count)
                    {
                        grpMusteri.Enabled = false;
                        ClearGuestGroup();
                    }
                }




            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }
        }

        private void ClearGuestGroup()
        {
            txtMusteriAd.Text = "";
            txtMusteriSoyad.Text = "";
            txtMusteriEmail.Text = "";
            mskPhone.Text = "";
            mskTC.Text = "";
            rtxtAdress.Text = "";
            dtpBirthDate.Value = DateTime.Now;
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
            FillRoomAndRoomType();
        }
        private void lstHotelList_DoubleClick(object sender, EventArgs e)
        {
            seciliHotelid = (Guid)lstHotelList.SelectedValue;
        }

        private void label11_Click(object sender, EventArgs e)
        {

        }

        private void cmbRoomType_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                List<Room> uygunodalar = null;
                if (cmbRoomType.SelectedIndex != -1)
                {
                    uygunodalar = roomService.GetAll().Where(x => x.RoomTypeID == (Guid)cmbRoomType.SelectedValue && x.HotelID == seciliHotelid).ToList();
                }
                if (uygunodalar != null)
                {
                    cmbRoom.DataSource = uygunodalar;
                    cmbRoom.DisplayMember = "RoomNumber";
                    cmbRoom.ValueMember = "ID";

                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }

        private void dtpCheckIn_ValueChanged(object sender, EventArgs e)
        {
            dtpCheckOut.MinDate = dtpCheckIn.Value.AddDays(1);
        }

        private void btnGuestDelete_Click(object sender, EventArgs e)
        {
            if (lstGuest.SelectedIndex != -1)
            {
                MessageBox.Show(guest.ToString());
                Guest deletedGuest = (Guest)lstGuest.SelectedItem;
                lstGuest.DataSource = null;
                lstGuest.DisplayMember = "FullName";
                lstGuest.ValueMember = "ID";
                Guid deletedGuestID = deletedGuest.ID;
                guest.Remove(guest.FirstOrDefault(x => x.ID == deletedGuestID));
                lstGuest.DataSource = guest;
                if (nmrGuest.Value > lstGuest.Items.Count)
                {
                    grpMusteri.Enabled = true;
                }
            }
            else MessageBox.Show("Lütfen silinecek misafiri seçiniz!");
        }

        Guest updatingGuest = null;
        int selectedindex = -1;
        private void btnGuestUpdate_Click(object sender, EventArgs e)
        {
            if (lstGuest.SelectedIndex != -1)
            {
                //Güncellemek için verileri group boxa ata
                selectedindex = lstGuest.SelectedIndex;
                grpHotelList.Enabled = false;
                grpBooking.Enabled = false;
                grpMusteri.Enabled = true;
                btnBookingUpdate.Enabled = false;
                btnBookingDelete.Enabled = false;
                btnGuestDelete.Enabled = false;
                btnGuestUpdate.Enabled = false;
                updatingGuest = lstGuest.SelectedItem as Guest;
                txtMusteriAd.Text = updatingGuest.FirstName;
                txtMusteriSoyad.Text = updatingGuest.LastName;
                txtMusteriEmail.Text = updatingGuest.Email;
                mskPhone.Text = updatingGuest.Phone;
                mskTC.Text = updatingGuest.TC;
                rtxtAdress.Text = updatingGuest.Address;
                dtpBirthDate.Value = updatingGuest.DateOfBirth.ToDateTime(new TimeOnly(0, 0));
            }
            else MessageBox.Show("Lütfen güncellenecek misafiri seçiniz!");
        }

        private void cmbRoom_SelectedIndexChanged(object sender, EventArgs e)
        {
            var room = (Room)cmbRoom.SelectedItem;
        }

        private void btnBookingSave_Click(object sender, EventArgs e)
        {
            try
            {
                if (boolupdateBooking == true)
                {
                    if (cmbRoom.SelectedValue == null) throw new Exception("Lütfen oda seçiniz!");
                    updateBooking.IsActive = true;

                    updateBooking.CheckinDate = DateOnly.FromDateTime(dtpCheckIn.Value);
                    updateBooking.CheckoutDate = DateOnly.FromDateTime(dtpCheckOut.Value);
                    List<Guest> silinecekguestler = updateBooking.Guests.ToList();
                    updateBooking.Guests = guest;



                    Room updatebookingroom = roomService.GetByID((Guid)cmbRoom.SelectedValue);

                    updateBooking.TotalPrice = updatebookingroom.PricePerNight * (dtpCheckOut.Value - dtpCheckIn.Value).Days;

                    updateBooking.RoomID = updatebookingroom.ID;
                    bookingService.UpdateBookingWithGuests(updateBooking, silinecekguestler);

                    boolupdateBooking = false;
                    grpHotelList.Enabled = true;

                    ClearGuestGroup();

                    lstGuest.DataSource = null;
                    guest = new List<Guest>();
                    nmrGuest.Value = 0;
                    lstGuest.ValueMember = "ID";
                    lstGuest.DisplayMember = "FullName";
                    lstGuest.DataSource = guest;
                    seciliHotelid = default(Guid);
                    cmbRoom.DataSource = null;
                    cmbRoomType.DataSource = null;


                    dtpCheckIn.Value = DateTime.Now;
                    dtpCheckOut.Value = DateTime.Now.AddDays(1);
                    btnBookingDelete.Enabled = true;
                    btnBookingUpdate.Enabled = true;
                    FillDataGrid();

                }
                else
                {
                    if (cmbRoom.SelectedIndex == -1)
                    {
                        throw new Exception("Oda seçilmedi! Lütfen uygun bir ode seçiniz. Uygun bir oda yoksa rezervasyon tercihlerinizi değiştiriniz.");
                    }
                    else if (nmrGuest.Value != lstGuest.Items.Count)
                    {
                        throw new Exception("Misafir listesinedeki misafir sayısı ile belirtilen misafir sayısı eşleşmemektedir!");
                    }
                    var bookingroom = (Room)cmbRoom.SelectedItem;
                    Booking booking = new Booking()
                    {
                        CheckinDate = DateOnly.FromDateTime(dtpCheckIn.Value),
                        CheckoutDate = DateOnly.FromDateTime(dtpCheckOut.Value),
                        Guests = guest,
                        TotalPrice = bookingroom.PricePerNight * (dtpCheckOut.Value - dtpCheckIn.Value).Days,
                        RoomID = bookingroom.ID,
                    };
                    bookingService.Add(booking);
                    Hotel hotelmis = hotelService.GetByID(bookingroom.HotelID);

                    MessageBox.Show("Hotel Adı:" + hotelmis.Name + "\nRezervasyon Başlangıç:" + booking.CheckinDate + "\nRezervasyon Bitiş:" + booking.CheckoutDate + "\nOda Numarası:" + bookingroom.RoomNumber + "\nToplam Ücret:" + booking.TotalPrice + " TL");

                    ClearGuestGroup();
                    guest = new List<Guest>();
                    lstGuest.DataSource = null;
                    lstGuest.ValueMember = "ID";
                    lstGuest.DisplayMember = "FullName";
                    lstGuest.DataSource = guest;
                    cmbRoom.DataSource = null;
                    cmbRoomType.DataSource = null;
                    nmrGuest.Value = 0;
                    seciliHotelid = default(Guid);

                    dtpCheckIn.Value = DateTime.Now;
                    dtpCheckOut.Value = DateTime.Now.AddDays(1);
                    FillDataGrid();
                    //cmbRoom.DataSource=null;
                    //cmbRoomType.DataSource = null;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnBookingDelete_Click(object sender, EventArgs e)
        {
            try
            {
                if (dgwBooking.Rows.Count == 0)
                {
                    throw new Exception("Silinecek rezervasyon yok! Lütfen rezervasyon seçiniz!");
                }
                Guid deletedID = (Guid)dgwBooking.CurrentRow.Cells["BookingID"].Value;
                if (deletedID == default(Guid))
                {
                    throw new Exception("Silinecek rezervasyon seçiniz!");
                }
                bookingService.Delete(deletedID);
                FillDataGrid();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        bool boolupdateBooking = false;
        Booking updateBooking;
        private void btnBookingUpdate_Click(object sender, EventArgs e)
        {
            try
            {
                if (dgwBooking.Rows.Count == 0)
                {
                    throw new Exception("Güncellenecek rezervasyon yok! Lütfen rezervasyon seçiniz!");
                }
                Guid updatingID = (Guid)dgwBooking.CurrentRow.Cells["BookingID"].Value;
                if (updatingID == default(Guid))
                {
                    throw new Exception("Güncellenecek rezervasyon seçiniz!");
                }
                lstGuest.DataSource = null;
                //nmrGuest.Value = 0;
                boolupdateBooking = true;

                var a = bookingService.GetAllBookingQueryable(updatingID);


                updateBooking = a.FirstOrDefault(x => x.ID == updatingID);

                updateBooking.IsActive = false;
                bookingService.Update(updateBooking);
                dtpCheckIn.Value = DateTime.Parse(updateBooking.CheckinDate.ToString());
                dtpCheckOut.Value = DateTime.Parse(updateBooking.CheckoutDate.ToString());





                maxindex = updateBooking.Guests.Count();
                nmrGuest.Value = maxindex;


                List<Guest> newguest = new List<Guest>();
                guest = newguest;
                nowindex = 0;
                foreach (var item in updateBooking.Guests.ToList())
                {
                    guest.Add((Guest)item);
                    nowindex++;
                }
                maxindex = nowindex;

                lstGuest.DataSource = null;
                lstGuest.DisplayMember = "FullName";
                lstGuest.ValueMember = "ID";


                seciliHotelid = roomService.GetByID(updateBooking.RoomID).HotelID;
                lstGuest.DataSource = guest.ToList();

                grpHotelList.Enabled = false;
                ClearGuestGroup();
                btnBookingUpdate.Enabled = false;
                btnBookingDelete.Enabled = false;
                if (nmrGuest.Value == lstGuest.Items.Count)
                {
                    grpMusteri.Enabled = false;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}