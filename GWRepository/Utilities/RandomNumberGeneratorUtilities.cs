using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GWRepository.Utilities
{
    public static class RandomNumberGeneratorUtilities
    {
        public static int GetRandomNumber(int max)
        {
            double seed = new Random().NextDouble();
            double timeSeed = (DateTime.UtcNow.Millisecond + 1) * Math.PI;
            seed += timeSeed * 100000;
            seed *= Math.E;
            double num = ((seed * 1983 / 24 * 32) % max) + 1;
            return (int)num;
        }
    }
}
