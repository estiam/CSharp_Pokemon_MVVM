using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media.Imaging;

namespace PokemonMVVM.Models
{
    public class PokemonData
    {
        public int Count { get; set; }
        public string Next { get; set; }
        public string Previous { get; set; }
        public List<Pokemon> Results { get; set; }
    }

    public class Pokemon
    {
        public int Id { get; set; }

        public string Name { get; set; }
        public String Url { get; set; }

        public int Height { get; set; }

        public int HeightCm
        {
            get
            {
                return Height * 10;
            }
        }

        public int Weight { get; set; }

        public float WeightKg
        {
            get
            {
                return Weight / 10;
            }
        }

        public List<TypeData> Types { get; set; }

        public string TypesAsString
        {
            get
            {
                string temp = "";

                Types.ForEach(x =>
                {
                    temp += x.Type.Name + ", ";
                });

                return temp;
            }
        }

        public List<MoveData> Moves { get; set; }

        public PokemonImgData Sprites { get; set; }

        public override string ToString()
        {
            return Name;
        }

    }

    public class TypeData
    {
        public int Slot { get; set; }
        public PType Type { get; set; }
    }

    public class PType
    {
        public String Name { get; set; }

    }

    public class MoveData
    {
        public PMove Move { get; set; }
    }

    public class PMove
    {
        public string Name { get; set; }
    }

    public class PokemonImgData
    {

        private string f_default;

        public string front_default
        {
            get { return f_default; }
            set { f_default = value; }
        }

        public BitmapImage PokemonImage
        {
            get
            {
                return new BitmapImage(new Uri(f_default));
            }
        }

    }


}
