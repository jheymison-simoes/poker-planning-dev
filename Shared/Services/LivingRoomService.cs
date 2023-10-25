using System;
using System.Collections.Generic;
using System.Linq;
using Shared.Exceptions;
using Shared.Helpers;
using Shared.Models;
using Shared.Services.Interfaces;

namespace Shared.Services;

public class LivingRoomService : ILivingRoomService
{
    private List<LivingRoom> _rooms = new();
    public EventHandler? AddPlayerHandler { get; set; }
    
    public LivingRoomService()
    {
    }

    public LivingRoom CreateRoom(string name)
    {
        var room = new LivingRoom(name);
        _rooms.Add(room);
        return room;
    }

    public LivingRoom GetById(Guid roomId)
    {
        var room = GetAndValidateRoomById(roomId);
        return room;
    }

    public Player AddParticipant(Guid roomId, string name)
    {
        var room = GetAndValidateRoomById(roomId);

        var existPlayer = room.Players.FirstOrDefault(p => p.Name == name);
        if (existPlayer is not null) return existPlayer;

        var player = new Player(name)
        {
            VotingCards = room.VotingCards.DeepClone()
        };

        room.Players.Add(player);
        
        AddPlayerHandler?.Invoke(this, new());
        
        return player;
    }
    
    public LivingRoom AddVote(Guid roomId, Guid playerId, VotingCard card)
    {
        var room = GetAndValidateRoomById(roomId);
        var player = room.Players.FirstOrDefault(p => p.Id == playerId);
        if (player is null) return room;
        player.Vote = card?.Value ?? default(int);
        
        AddPlayerHandler?.Invoke(this, new());
        
        return room;
    }

    public DuelResult Calculate(Guid roomId)
    {
        var room = GetAndValidateRoomById(roomId);
        var votes = room.Players.Where(p => p.Vote is > 0 and < 1000).Select(p => p.Vote).ToList();

        room.DuelResult = new DuelResult()
        {
            Average = votes.Any() ? votes.Average() : default,
            RoundedAverage = votes.Any() ? Math.Ceiling(votes.Average()) : default,
            HighestValue = votes.Any() ? votes.MaxBy(g => g) : default
        };
        
        AddPlayerHandler?.Invoke(this, new());

        return room.DuelResult;
    }

    public LivingRoom ResetVotes(Guid roomId)
    {
        var room = GetAndValidateRoomById(roomId);
        room.Players.ForEach(p =>
        {
            p.Vote = default;
            p.VotingCards.ForEach(vc => vc.Selected = false);
        });

        room.DuelResult = null;
        
        AddPlayerHandler?.Invoke(this, new());
        return room;
    }

    public int GetQuantityRooms() => _rooms.Count;

    public List<LivingRoom> GetRooms() => _rooms;

    public void SetRooms(List<LivingRoom> rooms) => _rooms = rooms;
    

    #region Private Methods

    private LivingRoom GetAndValidateRoomById(Guid roomId)
    {
        if (roomId == default) throw new CustomException("Não é possível buscar os dados da página pois o id informado não existe");
        
        var room = _rooms.FirstOrDefault(r => r.Id == roomId);
        if (room is null) throw new CustomException($"Não há nenhuma sala com este id '{roomId}'");

        return room;
    }
    #endregion
}

