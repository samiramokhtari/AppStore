using AppStore.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppStore.Biz
{
    public class UnitOfWork : IDisposable
    {
        //DB_Entities context = new DB_Entities();

        //private BaseBs<Transaction> transactionRepository;

        //public BaseBs<Transaction> TransactionRepository
        //{
        //    get
        //    {

        //        if (transactionRepository == null)
        //            transactionRepository = new BaseBs<Transaction>(context);


        //        return transactionRepository;
        //    }
        //}




        //private BaseBs<Login> loginRepository;

        //public BaseBs<Login> LoginReppository
        //{
        //    get
        //    {
        //        if (loginRepository == null)
        //            loginRepository = new BaseBs<Login>(context);

        //        return loginRepository;
        //    }
        //}

        //private BaseBs<DeviceFailureSetting> deviceFailureSettingRepository;

        //public BaseBs<DeviceFailureSetting> DeviceFailureSettingRepository
        //{
        //    get
        //    {
        //        if (deviceFailureSettingRepository == null)
        //            deviceFailureSettingRepository = new BaseBs<DeviceFailureSetting>(context);

        //        return deviceFailureSettingRepository;
        //    }
        //}


        //private BaseBs<Location> locationRepository;

        //public BaseBs<Location> LocationRepository
        //{
        //    get
        //    {

        //        if (locationRepository == null)
        //            locationRepository = new BaseBs<Location>(context);
        //        return locationRepository;
        //    }
        //}



        //private BaseBs<Device> deviceRepository;

        //public BaseBs<Device> DeviceRepository
        //{
        //    get
        //    {
        //        if (deviceRepository == null)
        //            deviceRepository = new BaseBs<Device>(context);
        //        return deviceRepository;
        //    }
        //}


        //private BaseBs<PersonelCard> personelRepository;

        //public BaseBs<PersonelCard> PersonelRepository
        //{
        //    get
        //    {
        //        if (personelRepository == null)
        //            personelRepository = new BaseBs<PersonelCard>(context);
        //        return personelRepository;

        //    }
        //}



        //private BaseBs<Tariff> tariffRepository;

        //public BaseBs<Tariff> TariffRepository
        //{
        //    get
        //    {
        //        if (tariffRepository == null)
        //            tariffRepository = new BaseBs<Tariff>(context);
        //        return tariffRepository;
        //    }
        //}


        //private BaseBs<Calendar> calendarRepository;

        //public BaseBs<Calendar> CalenderRepository
        //{
        //    get
        //    {
        //        if (calendarRepository == null)
        //            calendarRepository = new BaseBs<Calendar>(context);
        //        return calendarRepository;
        //    }
        //}


        //private BaseBs<DeviceSetting> deviceSettingRepository;

        //public BaseBs<DeviceSetting> DeviceSettingRepository
        //{
        //    get
        //    {
        //        if (deviceSettingRepository == null)
        //            deviceSettingRepository = new BaseBs<DeviceSetting>(context);
        //        return deviceSettingRepository;
        //    }
        //}

        //private BaseBs<Maintenance> maintenanceRepository;

        //public BaseBs<Maintenance> MaintenanceRepository
        //{
        //    get
        //    {
        //        if (maintenanceRepository == null)
        //            maintenanceRepository = new BaseBs<Maintenance>(context);
        //        return maintenanceRepository;
        //    }
        //}


        //private BaseBs<Error> errorsRepository;

        //public BaseBs<Error> ErrorsRepository
        //{
        //    get
        //    {
        //        if (errorsRepository == null)
        //            errorsRepository = new BaseBs<Error>(context);
        //        return errorsRepository;
        //    }

        //}


        //private BaseBs<LogSystem> logSystemRepository;

        //public BaseBs<LogSystem> LogSystemRepository
        //{
        //    get
        //    {
        //        if (logSystemRepository == null)
        //            logSystemRepository = new BaseBs<LogSystem>(context);
        //        return logSystemRepository;
        //    }

        //}


        //private BaseBs<MacAddress> macAddressRepository;

        //public BaseBs<MacAddress> MacAddressRepository
        //{
        //    get
        //    {
        //        if (macAddressRepository == null)
        //            macAddressRepository = new BaseBs<MacAddress>(context);
        //        return macAddressRepository;
        //    }
        //}


        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        private bool disposed = false;
        protected virtual void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                {
                    //context.Dispose();
                }
            }

            this.disposed = true;
        }
    }
}
