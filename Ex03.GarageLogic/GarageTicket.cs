using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ex03.GarageLogic
{
    public enum eVehicleStatus
    {
        InRepair,
        Repaired,
        PaidFor
    }

    public class GarageTicket
    {
        private string m_OwnerName;
        private string m_PhoneNumber;
        private string m_LicensePlate;
        private eVehicleStatus m_Status;

        public GarageTicket(string i_OwnerName, string i_PhoneNumber, eVehicleStatus i_Status,  string i_LicensePlate)
        {
            this.m_OwnerName = i_OwnerName;
            this.m_PhoneNumber = i_PhoneNumber;
            this.m_Status = i_Status;
            this.m_LicensePlate = i_LicensePlate;
        }

        public string OwnerName
        {
            get { return m_OwnerName; }
            set { m_OwnerName = value; }
        }

        public string LicensePlate
        {
            get { return m_LicensePlate; }
            set { m_LicensePlate = value; }
        }

        public string PhoneNumber
        {
            get { return m_PhoneNumber; }
            set { m_PhoneNumber = value; }
        }

        public eVehicleStatus Status
        {
            get { return m_Status; }
            set { m_Status = value; }
        }

        public void GetInfo(List<String> i_Info)
        {
            i_Info.Add("The Owner is " + OwnerName);
            i_Info.Add("The PhoneNumber is " + PhoneNumber);
            i_Info.Add("The vehicle's status  is " + Status.ToString());
        }
    }
}