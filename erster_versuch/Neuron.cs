using System;
using System.Collections.Generic;
using MathNet.Numerics;
namespace erster_versuch
{
    public class Neuron
    {
        private List<double> weights;
        private double bias;
        public double Value { get; set; } = 0;


        public double calculate_value(Layer prev_Layer)
        {
            double temp_value = 0;
            for (int i = 0; i < weights.Count; i++)
                
            {
                temp_value += weights[i] * prev_Layer.Neurons[i].Value;
            }
            
            Value = 1 / (1 + Math.Pow(Constants.E, -1*(temp_value+bias)));
            return Value;
            
        }

        public override string ToString()
        {
            return "";
        }
    }
}
