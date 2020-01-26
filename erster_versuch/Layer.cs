using System;
using System.Collections.Generic;

namespace erster_versuch
{
    public class Layer
    {
        public List<Neuron> Neurons { get; }


        public Layer(int capacity)
        {
            Neurons = new List<Neuron>(capacity);
            for (int i = 0; i < capacity; i++)
            {
                Neurons.Add(new Neuron());
            }
        }

        public void CalculateValues(Layer prev_layer = null, List<double> inputs = null)
        {
            if (prev_layer == null)
            {
                for (int i = 0; i < Neurons.Count; i++)
                {
                    Neurons[i].calculate_value(inputs)
                }
            }
            else
            {
                for(int i = 0; i<Neurons.Count;i++)
                {
                    Neurons[i].calculate_value(prev_layer);
                }
            }
        }
        public override string ToString()
        {
            return Neurons.ToString();
        }    
    }
    
}
