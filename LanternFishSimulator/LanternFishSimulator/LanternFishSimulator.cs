using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LanternFishSimulator
{
    public class LanternFishSimulator
    {
        private List<Lanternfish> fishes;
        private List<List<Lanternfish>> dailyPopulation = new List<List<Lanternfish>>();

        public LanternFishSimulator(List<Lanternfish> _fishes) => fishes = _fishes;

        public List<Lanternfish> GetLanternFishPopulation(int days)
        {
            dailyPopulation.Add(fishes);
            for (int i = 0; i < days; i++)
            {
                fishes.AddRange(MakeFishesDaily());
                dailyPopulation.Add(fishes);
            }
            return fishes;
        }

        private List<Lanternfish> MakeFishesDaily()
        {
            var newFishes = new List<Lanternfish>();
            for (int j = 0; j < fishes.Count; j++)
            {
                fishes[j].NextDay();
                var fish = fishes[j].TryBirth();
                if (fish != null)
                    newFishes.Add(fish);
            }
            return newFishes;
        }

        public void PrintPopulation(int days)
        {
            foreach (var population in dailyPopulation)
            {
                Console.WriteLine(string.Concat(population.Select(x => x.Timer.ToString() + " ")));
            }
        }
    }
}
