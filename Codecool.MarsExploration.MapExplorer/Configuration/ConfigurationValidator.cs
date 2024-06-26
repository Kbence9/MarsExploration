﻿using Codecool.MarsExploration.MapGenerator.Calculators.Model;
using Codecool.MarsExploration.MapGenerator.Calculators.Service;
using Codecool.MarsExploration.MapGenerator.MapElements.Model;

namespace Codecool.MarsExploration.MapExplorer.Configuration;

public class ConfigurationValidator : IConfigurationValidator
{
    public bool Validate(Map map, Configuration config)
    {
        var validationResults = new List<bool>()
        {
            IsLandingSpotValid(map, config.LandingCoordinate),
            IsMapFileValid(config.MapFile),
            IsThereResources(config.Resources),
            IsTimeOutGreaterThenZero(config.MaxSteps)
        };

        return !validationResults.Contains(false);
    }

    private static bool IsLandingSpotValid(Map map, Coordinate landingCoordinate)
    {
        var adjacentCoordinates = new CoordinateCalculator().GetAdjacentCoordinates(landingCoordinate, map.Dimension);
        var isThereEmptySpaceAdjacentToLandingSpot = false;
        foreach (var coordinate in adjacentCoordinates)
        {
            if (map.Representation[coordinate.X, coordinate.Y] == " ")
            {
                isThereEmptySpaceAdjacentToLandingSpot = true;
            }
        }
        return map.Representation[landingCoordinate.X, landingCoordinate.Y] == " "  && isThereEmptySpaceAdjacentToLandingSpot;

    }
    
    private static bool IsMapFileValid(string filePath)
    {
        return File.Exists(filePath);
    }

    private static bool IsThereResources(IEnumerable<string> resources)
    {
        return resources.Any();
    }

    private static bool IsTimeOutGreaterThenZero(int timeout)
    {
        return timeout > 0;
    }
}