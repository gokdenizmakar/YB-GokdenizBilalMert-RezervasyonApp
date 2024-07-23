using Autofac;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using YB.Business.Abstractions;
using YB.Business.Services;
using YB.DataAccess.Abstractions;
using YB.DataAccess.Context;
using YB.DataAccess.Repositories.EntityFramework;

namespace YB.Business.DependicyInjection.AutoFac
{
    public class AutofacBusinessModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<ApplicationDbContext>().AsSelf().SingleInstance();
            builder.RegisterType<EFBookingDal>().As<IBookingDal>();
            builder.RegisterType<EFGuestDal>().As<IGuestDal>();
            builder.RegisterType<EFHotelDal>().As<IHotelDal>();
            builder.RegisterType<EFPaymentDal>().As<IPaymentDal>();
            builder.RegisterType<EFRoomDal>().As<IRoomDal>();
            builder.RegisterType<EFRoomTypeDal>().As<IRoomTypeDal>();
            builder.RegisterType<EFStaffDal>().As<IStaffDal>();

            builder.RegisterType<BookingService>().As<IBookingService>();
            builder.RegisterType<GuestService>().As<IGuestService>();
            builder.RegisterType<HotelService>().As<IHotelService>();
            builder.RegisterType<PaymentService>().As<IPaymentService>();
            builder.RegisterType<RoomService>().As<IRoomService>();
            builder.RegisterType<RoomTypeService>().As<IRoomTypeService>();
            builder.RegisterType<StaffService>().As<IStaffService>();



        }
    }
}
