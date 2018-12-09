﻿using System;

namespace ArtiLib.Utils
{
    public class Singleton<T> where T : new()
    {
        private Singleton()
        {
        }

        private static readonly Lazy<T> instance = new Lazy<T>(() => new T());

        public static T Instance { get { return instance.Value; } }
    }
}