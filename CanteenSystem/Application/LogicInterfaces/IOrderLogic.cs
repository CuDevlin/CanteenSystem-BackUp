﻿using Shared.Model;

namespace Application.LogicInterfaces;

public interface IOrderLogic
{
    Task<IEnumerable<Order>> GetAllPostsAsync();
}