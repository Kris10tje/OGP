using OGP.Interface;
using System;

namespace OGP.Model
{
    public class Temperature: ITemperature
    {
        const int MAXHOTNESSCOLDNESS = 10000;

        public int Hotness { get; private set; }
        public int Coldness { get; private set; }

        void AlterTemp(int temp)
        {
            var newTemp = (Coldness * (-1)) + temp;
            if (newTemp < MAXHOTNESSCOLDNESS)
            {
                if (newTemp > 0)
                {
                    Coldness = 0;
                    Hotness = newTemp;
                }
                else
                {
                    Coldness -= newTemp;
                    Hotness = 0;
                }
            }
        }
        public void Heat(int temp)
        {
            if (temp > 0)
                AlterTemp(temp);
        }

        
        public void Cool(int temp)
        {
            if (temp > 0)
                AlterTemp(temp * -1);
        }

        /// <summary>
        /// returns the differenct between the current temperature and the given termperature
        /// </summary>
        /// <param name="temperature"></param>
        /// <returns>will return the difference. If the difference is > 0 this means the given temperature was hotter</returns>
        public int Diff(ITemperature temperature)
        {
            var currenttemp = (Coldness * -1) + Hotness;
            var resulttemp = (temperature.Coldness * -1) + temperature.Hotness;
            return resulttemp - currenttemp;
        }

    }
}
