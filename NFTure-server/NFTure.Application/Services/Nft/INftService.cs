﻿using NFTure.Application.Models;

namespace NFTure.Application.Services
{
    public interface INftService
    {
        Task<IEnumerable<NftModel>> GetNftsByOwnerIdAsync(Guid ownerId);
        Task<NftModel> AddNewNftAsync(NftModel nftModel);
        Task UpdateNftAsync(NftModel newNft);
        Task<int> GetUserNftCountAsync(Guid userId);
    }
}
