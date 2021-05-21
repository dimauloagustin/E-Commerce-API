﻿namespace Application.Interfaces.Services
{
    public interface IHashService
    {
        string Hash(string value);
        bool Verify(string value, string hashedValue);
    }
}
