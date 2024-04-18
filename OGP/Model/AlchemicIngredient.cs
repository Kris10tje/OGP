using OGP.Interface;
using System;

namespace OGP.Model
{
    public class AlchemicIngredient: IAlchemicIngredient
    {
        public ITemperature Temperature { get; set; }
    }
}
