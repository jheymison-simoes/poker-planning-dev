using System;
using System.Collections.Generic;
using System.Linq;

namespace Shared.Models;

public class LivingRoom
{
    public Guid Id { get; set; }
    public string Name { get; set; }
    public List<Player> Players { get; set; } = new();
    public List<VotingCard> VotingCards { get; set; } = new();
    public DuelResult DuelResult { get; set; }
    private DateTime CreatedAt { get; set; }

    private const int MaxVotingOptions = 11; 
    private readonly List<int> _exceptionNumbers = new() { 0, 1 };

    public LivingRoom(string name)
    {
        Id = Guid.NewGuid();
        Name = name;
        CreatedAt = DateTime.UtcNow;
        VotingCards = CreateVotingOptions();
    }

    private List<VotingCard> CreateVotingOptions()
    {
        var fibonacciNumbers = new List<int>();
        for (var i = 0; i < MaxVotingOptions; i++) fibonacciNumbers.Add(Fibonacci(i));
        
        var options = fibonacciNumbers.Where(f => !_exceptionNumbers.Contains(f))
            .Select(f => new VotingCard(Guid.NewGuid(), f, f.ToString()))
            .ToList();

        options.Add(new VotingCard(Guid.NewGuid(), 1000, "?"));
        options.Add(new VotingCard(Guid.NewGuid(), 1001, "Coffe"));
        
        return options;
    }
    
    private static int Fibonacci(int n)
    {
        if (n <= 1)
        {
            return n;
        }
        else
        {
            return Fibonacci(n - 1) + Fibonacci(n - 2);
        }
    }
}

public class VotingCard
{
    public Guid Id { get; set; }
    public int Value { get; set; }
    public string Description { get; set; }
    public bool Selected { get; set; }
    
    public VotingCard(Guid id, int value, string description)
    {
        Id = id;
        Value = value;
        Description = description;
    }
}

public class Player
{
    public Guid Id { get; set; }
    public string Name { get; set; }
    public int Vote { get; set; }
    public List<VotingCard> VotingCards { get; set; } = new();
    
    public Player(string name)
    {
        Id = Guid.NewGuid();
        Name = name;
    }
}

public class DuelResult
{
    public double Average { get; set; }
    public double RoundedAverage { get; set; }
    public double Majority { get; set; }
    public int HighestValue { get; set; }
};