using System;
using System.Collections.Generic;

namespace erster_versuch
{
    class Program
    {
        
        
        static void Main(string[] args)
        {
        Parser parser = new Parser();
        parser.Parse("training_data/train-images-idx3-ubyte", "training_data/train-labels-idx1-ubyte");
        Network network = new Network(28*28,10,2,40);
        network.Cycle(parser.Images);
        }
       
    }
}