using System;
using System.Collections.Generic;
using System.Text;

namespace LanternFishSimulator
{
    public class Lanternfish
    {
        public int Timer { get; private set; }

        public Lanternfish(int _timer) => Timer = _timer;

        public void NextDay() => Timer--;

        public Lanternfish TryBirth()
        {
            if (Timer != -1)
                return null;

            Timer = 6;
            return new Lanternfish(8);
        }
    }
}
