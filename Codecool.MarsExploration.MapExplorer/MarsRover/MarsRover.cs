﻿using Codecool.MarsExploration.MapGenerator.Calculators.Model;
using Codecool.MarsExploration.MapGenerator.MapElements.Model;

namespace Codecool.MarsExploration.MapExplorer.MarsRover
{
    public class MarsRover {
        public string Id { get; }
        public Coordinate Position { get; set; }
        public int Sight { get; }
        public Dictionary<Coordinate, MapElement> ResourcesCollection { get; set; }

        public MarsRover(string id, Coordinate position, int sight, Dictionary<Coordinate, MapElement> resourcesCollection)
        {
            Id = id;
            Position = position;
            Sight = sight;
            ResourcesCollection = resourcesCollection;
        }
    }
}