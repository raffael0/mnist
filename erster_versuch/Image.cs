using System;

namespace erster_versuch
{ 
    public class Image
    {
        public double[] Inputs { get; set; }
        public double LabelValue { get; set; }

        public Image()
        {
            Inputs = new double[28 * 28];
        }

        public override string ToString()
        {
            string output = "";
            output += LabelValue + " /n ";
            for (int i = 0; i < 28; i++)
            {
                for (int j = 0; j < 28; j++)
                {
                    output += Inputs[i * j] + " ";
                    for (int k = Inputs[i * j].ToString().Length; k < 3; k++)
                    {
                        output += " ";
                    }
                }

                output += " /n ";
            }

            return output;
        }
    }
}