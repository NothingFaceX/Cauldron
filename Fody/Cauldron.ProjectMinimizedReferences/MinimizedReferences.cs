﻿using Cauldron.Interception.Cecilator;
using Cauldron.Interception.Fody;

public static class MinimizedReferences
{
    public const string Name = "Project minimize references";
    public const int Priority = int.MaxValue;

    [Display("Delete Members without usage")]
    public static void Z_Implement(Builder builder)
    {
    }
}