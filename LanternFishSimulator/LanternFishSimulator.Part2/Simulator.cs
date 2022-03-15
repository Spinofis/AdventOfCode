using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LanternFishSimulator.Part2
{
    public class Simulator
    {
        const int FISH_DAYS = 9;
        private long[] initialFishes;

        public Simulator(long[] fishes)
        {
            initialFishes = new long[FISH_DAYS];
            for (int i = 0; i < FISH_DAYS; i++)
                initialFishes[i] = fishes.Where(p => p == i).Count();
        }

        public long[] GetNumberOfFishEachDay(int day, bool printDay = false)
        {
            long[] fishes = new long[FISH_DAYS];
            for (int i = 0; i < FISH_DAYS; i++)
                fishes[i] = initialFishes[i];
            for (int i = 0; i < day; i++)
                fishes = ProcessDay(fishes);

            return fishes;
        }

        public long[] ProcessDay(long[] fishes)
        {
            long[] prevFishes = new long[FISH_DAYS];
            for (long i = 0; i < FISH_DAYS; i++)
                prevFishes[i] = fishes[i];
            for (long i = 0; i < FISH_DAYS - 1; i++)
                fishes[i] = prevFishes[i + 1];
            fishes[8] = 0;
            fishes[6] += prevFishes[0];
            fishes[8] += prevFishes[0];
            return fishes;
        }
    }
}
