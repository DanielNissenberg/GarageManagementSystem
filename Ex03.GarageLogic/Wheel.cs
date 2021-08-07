using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ex03.GarageLogic
{
     public class Wheel
     {
         private String m_Manufacturer;
         private float m_CurrentAirPressure;


        private readonly float m_MaxAirPressureRecommended;

         public Wheel(string i_Manufacturer, float i_CurrentAirPressure, float i_MaxAirPressureRecommended)
         {
             m_Manufacturer = i_Manufacturer;
             m_CurrentAirPressure = i_CurrentAirPressure;
             m_MaxAirPressureRecommended = i_MaxAirPressureRecommended;
         }

         public string Manufacturer
         {
             get { return m_Manufacturer; }
             set { m_Manufacturer = value; }
         }

         public float CurrentAirPressure
         {
             get { return m_CurrentAirPressure; }
             set { m_CurrentAirPressure = value; }
         }

         public float MaxAirPressureRecommended
         {
            get { return m_MaxAirPressureRecommended; }
         }

         public void InflateTyre(float i_HowMuchToInflate)
         {
             if(m_CurrentAirPressure + i_HowMuchToInflate <= m_MaxAirPressureRecommended)
             {
                 m_CurrentAirPressure = m_CurrentAirPressure + i_HowMuchToInflate;
             }
             else
             {
                 m_CurrentAirPressure = m_MaxAirPressureRecommended;
             }
         }

         public void InflateTyreToMax()
         {
             m_CurrentAirPressure = m_MaxAirPressureRecommended;
         }
     }
}