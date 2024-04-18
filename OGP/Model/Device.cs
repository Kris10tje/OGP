using OGP.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;

namespace OGP.Model
{
    /// <summary>
    /// Alchemische Toestellen kunnen worden gebruikt om alchemische bewerkingen uit te voeren
    /// op de ingredi¨enten.Ze vormen meteen ook de enige manier om veranderingen aan te brengen
    /// aan alchemische ingredi¨enten.Alle toestellen zullen om die reden de volgende drie methodes
    /// aanbieden:
    /// </summary>
    public abstract class Device
    {
        int? _maxNumberOfContainers;
        public List<IIngredientContainer> IngredientContainers { get; private set; }


        public Device(int? maxNumberOfContainers = null) 
        {
            IngredientContainers = new List<IIngredientContainer>();
            _maxNumberOfContainers = maxNumberOfContainers;
        }

        /// <summary>
        /// Een methode om er hoeveelheden ingredi¨ent in te stoppen. Deze zal een ingredi¨entencontainer
        /// als argument krijgen, die na uitvoering leeg zal zijn.Omdat alchemisten niet graag
        /// hun containers schoonmaken worden deze voorgoed verwijderd na hun gebruik.
        /// </summary>
        /// <param name="container"></param>
        public void AddIngredient(IIngredientContainer container)
        {
            if (_maxNumberOfContainers.HasValue && IngredientContainers.Count + 1 > _maxNumberOfContainers)
                throw new Exception("Max number of containers reached");

            IngredientContainers.Add(container);
        }

        /// <summary>
        /// Een methode om het resultaat van de alchemische bewerking terug uit het toestel te
        /// halen.Deze zal een nieuwe ingredi¨entencontainer aan de gebruiker teruggeven, gevuld
        /// met de resulterende hoeveelheid ingredi¨ent.
        /// </summary>
        /// <returns></returns>
        public IngredientContainer GetContent()
        {
            return null;
        }

        /// <summary>
        /// Een methode om de alchemische bewerking van het toestel uit te voeren
        /// </summary>
        public virtual void ProcessContainers()
        {
            if (IngredientContainers == null || !IngredientContainers.Any())
                throw new Exception("No containers to process");
        }
    }

    public class CoolingBox : Device
    {
        Temperature _temperature;
        public CoolingBox(Temperature temperature): base(1)
        {
            _temperature = temperature;
        }

        public override void ProcessContainers()
        {
            base.ProcessContainers();
            var diff = _temperature.Diff(IngredientContainers[0].Ingredient.Temperature);
            if (diff > 0)
                IngredientContainers[0].Ingredient.Temperature.Cool(diff);
        }
    }

    public class Oven : Device
    {
    }

    public class Kettle : Device
    {
    }

    public class Transmogrifier : Device
    {
    }
}
