using System;
using System.Collections.Generic;
using MathNet.Numerics;
using MathNet.Numerics.RootFinding;

namespace erster_versuch
{
    public class Neuron
    {
        public List<double> Weights { get; }
        public double Bias { get; set; }
        public double Value { get; set; }
        
        public double NetValue { get; set; }
        public Neuron(int amountWeights)
        {
            NetValue = 0;
            Bias = 1;
            var r = new Random();
            var minimum = -.5;
            
            var maximum = 0.5;
            Weights = new List<double>();
            for (var i = 0; i < amountWeights; i++)
            {
                var rand = r.NextDouble() * (maximum - minimum) + minimum;

                Weights.Add(rand);
            }
            NetValue = r.NextDouble() * (maximum - minimum) + minimum;

        }

        public double calculate_value(Layer prevLayer)
        {
            double tempValue = 0;
            for (int i = 0; i < Weights.Count; i++)

            { 
                tempValue += Weights[i] * prevLayer.Neurons[i]. Value;
            }

            NetValue = tempValue;
            Value = 1 / (1 + Math.Pow(Constants.E, -1 * (tempValue + Bias)));
            return Value;

        }
        
        public override string ToString()
        {
            return Bias + "";
        }
    }
}
 