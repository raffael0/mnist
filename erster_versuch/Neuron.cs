using System;
using System.Collections.Generic;
using MathNet.Numerics;
namespace erster_versuch
{
    public class Neuron
    {
        public List<double> Weights { get; set; }
        public double Bias { get; set; }
        public double Value { get; set; } = 0;
        
        public double NetValue { get; set; }
        public Neuron(int amountWeights)
        {
            Random r = new Random();
            double minimum = -.5;
            double maximum = 0.5;
            weights = new List<double>();
            for (int i = 0; i < amountWeights; i++)
            {
                weights.Add(r.NextDouble() * (maximum - minimum) + minimum);
            }
        }

        public double calculate_value(Layer prevLayer)
        {
            double tempValue = 0;
            for (int i = 0; i < weights.Count; i++)

            {
                tempValue += weights[i] * prevLayer.Neurons[i].Value;
            }

            NetValue = tempValue;
            Value = 1 / (1 + Math.Pow(Constants.E, -1 * (tempValue + bias)));
            return Value;

        }
        
        

        public override string ToString()
        {
            return Value + "";
        }
    }
}
