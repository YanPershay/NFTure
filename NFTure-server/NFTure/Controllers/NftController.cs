using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using NFTure.Application.Services;
using NFTure.Core.Entities;
using NFTure.Web.Controllers.Base;
using NFTure.Web.DTOs.NFT;

namespace NFTure.Web.Controllers
{

    //[Authorize(Roles = "User")]
    public class NftController : ApiController
    {
        private readonly INftService _nftService;
        private readonly IMapper _mapper;

        public NftController(INftService nftService, IMapper mapper)
        {
            _nftService = nftService;
            _mapper = mapper;
        }

        /// <summary>
        /// Test endpoint for getting any NFT entity
        /// </summary>
        [HttpGet("id")]
        public async Task<ActionResult<NftResponse>> GetNftById(Guid id)
        {
            var nft = await _nftService.GetNftByIdAsync(id);

            var mappedNft = _mapper.Map<NftResponse>(nft);

            return Ok(mappedNft);
        }

        //TODO: Add 401, 403 etc. codes to summary when auth will be added
        /// <summary>
        /// Returns all NFTs for user by user ID
        /// </summary>
        /// <remarks>
        /// User ID must be Guid
        /// </remarks>
        /// <param name="ownerId">ownerId</param>
        /// <response code="200">List of NFTs</response>
        /// <response code="400">Incorrect user ID</response>
        [HttpGet]
        public async Task<ActionResult<IEnumerable<NftResponse>>> GetNftsByOwnerId(Guid ownerId)
        {
            var nfts = await _nftService.GetNftsByOwnerIdAsync(ownerId);

            var mappedNfts = _mapper.Map<IEnumerable<NftResponse>>(nfts);

            return Ok(mappedNfts);
        }

        /// <summary>
        /// Add new NFT
        /// </summary>
        /// <response code="200">Created NFT entity</response>
        /// <response code="400">Validation error</response>
        [HttpPost]
        public async Task<ActionResult<NftResponse>> AddNewNft(CreateNftRequest nft)
        {
            var mappedModel = _mapper.Map<Nft>(nft);

            var createdNft = await _nftService.AddNewNftAsync(mappedModel);
            
            var mappedNft = _mapper.Map<NftResponse>(createdNft);

            return Ok(mappedNft);
        }

        /// <summary>
        /// Update NFT data
        /// </summary>
        /// <response code="204">NFT successfully updated</response>
        /// <response code="400">Validation error</response>
        [HttpPut]
        public async Task<ActionResult> UpdateNft(UpdateNftRequest nft)
        {
            var mappedModel = _mapper.Map<Nft>(nft);

            await _nftService.UpdateNftAsync(mappedModel);

            return NoContent();
        }

        /// <summary>
        /// Returns the number of user's NFTs
        /// </summary>
        /// <remarks>
        /// User ID must be Guid
        /// </remarks>
        /// <param name="id">id</param>
        /// <response code="200">Count of user's NFTs</response>
        /// <response code="400">Incorrect user ID</response>
        [HttpGet("count/{id}")]
        public async Task<ActionResult<IEnumerable<NftResponse>>> GetUserNftCount(Guid id)
        {
            int count = await _nftService.GetUserNftCountAsync(id);

            return Ok(count);
        }
    }
}
