using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LanternFishSimulator.Part2
{
    public class Simulator
    {
        const int FISH_DAYS = 9;
        private int[] initialPopulation;

        public Simulator(int[] fishes)
        {
            initialPopulation = new int[FISH_DAYS];
            for (int i = 0; i < FISH_DAYS; i++)
                initialPopulation[i] = fishes.Where(p => p == i).Count();
        }

        public int[] GetPopulation(int day, bool printPopulation = false)
        {
            int[] population = new int[FISH_DAYS];
            for (int i = 0; i < FISH_DAYS; i++)
                population[i] = initialPopulation[i];
            for (int i = 0; i < day; i++)
                population = ProcessDay(population);
            if (printPopulation)
                foreach (var f in population)
                    Console.Write(f + ", ");
            Console.WriteLine();
            return initialPopulation;
        }

        public int[] ProcessDay(int[] population)
        {
            int[] prevPopulation = new int[FISH_DAYS];
            for (int i = 0; i < FISH_DAYS; i++)
                prevPopulation[i] = population[i];
            for (int i = 0; i < FISH_DAYS - 1; i++)
                population[i] = prevPopulation[i + 1];
            population[5] += prevPopulation[0];
            population[7] += prevPopulation[0];
            return population;
        }
    }
}
