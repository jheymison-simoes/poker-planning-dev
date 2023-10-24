using System;
using Shared.Models;

namespace Shared.Services.Interfaces;

public interface ILivingRoomService
{
    LivingRoom CreateRoom(string name);
    LivingRoom GetById(Guid roomId);
    Player AddParticipant(Guid roomId, string name);
    EventHandler? AddPlayerHandler { get; set; }
    LivingRoom AddVote(Guid roomId, Guid playerId, VotingCard card);
    DuelResult Calculate(Guid roomId);
    LivingRoom ResetVotes(Guid roomId);
    int GetQuantityRooms();
}