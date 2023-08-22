using API.Entities;
using Microsoft.EntityFrameworkCore;

namespace API.Data
{
    public class Seed
    {
        public static async Task SeedUsers(DataContext context)
        {
            if (await context.Watches.AnyAsync()) return;

            Watch watch1 = new Watch()
            {
                Id = 1,
                Name = "TOP TIME B01",
                ItemNumber = "RB01761A1Q1X1",
                Price = 1172000,
                ShortDescription = "Nice watch 1",
                FullDescription = "The 1960s was a decade of experimentation, fun, freedom and energy. Whether cruising on a motorcycle or revving up a sportscar, living life at full speed was the order of the day. Willy Breitling felt this change of pace and set out to design an unconventional chronograph that would capture the verve of era. He called it the Top Time. That spirited tradition continues today with the Top Time B01 that features a perforated leather racing strap, speed-measuring tachymeter scale and contrasting “squircle” (not quite square, not quite round) subdials that give the feel of a vintage dashboard gauge. It also comes with a brag-worthy engine under the hood: the exceptional Breitling Manufacture Caliber 01.",
                Caliber = "Breitling 01",
                Movement = "Self-winding mechanical",
                Chronograph = "1/4th second, 30 minutes, 12 hours",
                Jewel = 40,
                Weight = 160.0f,
                Diameter = 41.0f,
                Height = 50.0f,
                Thickness = 10.0f,
                CaseMaterial = "18k red gold",
                StrapMaterial = "Calfskin leather",
                PhotoUri = "./img/toptime-41-gold-cuir-front-rb01761a1q1x1-4"
            };

            context.Watches.Add(watch1);

            Watch watch2 = new Watch()
            {
                Id = 2,
                Name = "NAVITIMER B01 CHRONOGRAPH 41",
                ItemNumber = "RB0139631G1P1",
                Price = 1588000,
                ShortDescription = "Nice watch 2",
                FullDescription = "Breitling’s iconic pilot’s chronograph – for the journey. In 1952, Willy Breitling developed a wrist-worn chronograph with a circular slide rule that would allow pilots to perform all necessary flight calculations. Two years later, the Aircraft Owners and Pilots Association (AOPA) announced the design as its official timepiece. The “navigation timer” – or Navitimer – was born. The AOPA was (and remains) the largest pilots’ club in the world, counting nearly every US aviator among its ranks. As the defacto pilot’s watch throughout the glory days of civil aviation, the Navitimer was worn by airline captains and aircraft enthusiasts. It even made its way into space on the wrist of astronaut Scott Carpenter in 1962. And it wasn’t only pilots drawn to the watch’s irrepressible aesthetic. Celebrities of the day such as Miles Davis and Serge Gainsbourg were devotees, proving that the Navitimer had style as well as function. There have been many iterations of Breitling’s icon since its debut 70 years ago, but this new Navitimer captures its most classic features, while enhancing them with modern refinements. A flattened slide rule and a domed crystal create the illusion of a sleeker profile. Alternating polished and brushed metal elements give a lustrous, yet understated finish. Most notably, new colors in shades of blue, green and copper, define the updated dial options. And if there is one update sure to spark nostalgia, it’s the return of the AOPA wings to their original position at 12 o’clock. For 70 years, Breitling’s original pilot’s watch has been beloved by aviators and tastemakers in equal measure. Worn by astronauts in space and the biggest stars on earth, it is Breitling’s most iconic timepiece and one of the most recognizable watches of all time.",
                Caliber = "Breitling 01",
                Movement = "Self-winding mechanical",
                Chronograph = "1/4th second, 30 minutes, 12 hours",
                Jewel = 47,
                Weight = 91.0f,
                Diameter = 41.0f,
                Height = 47.0f,
                Thickness = 13.6f,
                CaseMaterial = "18k red gold",
                StrapMaterial = "Calfskin leather",
                PhotoUri = "./img/rb0139631g1p1-navitimer-b01-chronograph-41-soldier"
            };

            context.Watches.Add(watch2);

            Watch watch3 = new Watch()
            {
                Id = 3,
                Name = "NAVITIMER B01 CHRONOGRAPH 41",
                ItemNumber = "AB0139631C1P1",
                Price = 1172000,
                ShortDescription = "Nice watch 3",
                FullDescription = "The 1960s was a decade of experimentation, fun, freedom and energy. Whether cruising on a motorcycle or revving up a sportscar, living life at full speed was the order of the day. Willy Breitling felt this change of pace and set out to design an unconventional chronograph that would capture the verve of era. He called it the Top Time. That spirited tradition continues today with the Top Time B01 that features a perforated leather racing strap, speed-measuring tachymeter scale and contrasting “squircle” (not quite square, not quite round) subdials that give the feel of a vintage dashboard gauge. It also comes with a brag-worthy engine under the hood: the exceptional Breitling Manufacture Caliber 01.",
                Caliber = "Breitling 01",
                Movement = "Self-winding mechanical",
                Chronograph = "1/4th second, 30 minutes, 12 hours",
                Jewel = 47,
                Weight = 91.0f,
                Diameter = 41.0f,
                Height = 47.0f,
                Thickness = 13.6f,
                CaseMaterial = "18k red gold",
                StrapMaterial = "Calfskin leather",
                PhotoUri = "./img/ab0139631c1p1-navitimer-b01-chronograph-41-soldier"
            };

            context.Watches.Add(watch3);

            Watch watch4 = new Watch()
            {
                Id = 4,
                Name = "ENDURANCE PRO IRONMAN® WORLD CHAMPIONSHIP",
                ItemNumber = "E823103A1M1S1",
                Price = 1172000,
                ShortDescription = "Nice watch 4",
                FullDescription = "The 1960s was a decade of experimentation, fun, freedom and energy. Whether cruising on a motorcycle or revving up a sportscar, living life at full speed was the order of the day. Willy Breitling felt this change of pace and set out to design an unconventional chronograph that would capture the verve of era. He called it the Top Time. That spirited tradition continues today with the Top Time B01 that features a perforated leather racing strap, speed-measuring tachymeter scale and contrasting “squircle” (not quite square, not quite round) subdials that give the feel of a vintage dashboard gauge. It also comes with a brag-worthy engine under the hood: the exceptional Breitling Manufacture Caliber 01.",
                Caliber = "Breitling 01",
                Movement = "Self-winding mechanical",
                Chronograph = "1/4th second, 30 minutes, 12 hours",
                Jewel = 4,
                Weight = 86.5f,
                Height = 52.4f,
                Diameter = 44.0f,
                Thickness = 12.5f,
                CaseMaterial = "18k red gold",
                StrapMaterial = "Calfskin leather",
                PhotoUri = "./img/e823103a1m1s1-endurance-pro-ironman-world-championship-soldier"
            };

            context.Watches.Add(watch4);

            await context.SaveChangesAsync();
        }
    }
    }
