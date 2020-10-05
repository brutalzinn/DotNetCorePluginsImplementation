﻿using System;
using System.Collections.Generic;
using DependencyInjection;

namespace MyPlugin1
{
    internal class MyFruitProducer : IFruitProducer
    {
        public IEnumerable<Fruit> Produce()
        {
            yield return new Fruit("banana");
            yield return new Fruit("orange");
            yield return new Fruit("strawberry");
        }
    }
}
