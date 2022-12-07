using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using NFTure.Application;
using NFTure.Application.Models;
using NFTure.Web.Controllers.Base;
using NFTure.Web.DTOs.NFT;

namespace NFTure.Web.Controllers
{
    public class NftController : ApiController
    {
        private readonly INftService _nftService;
        private readonly IMapper _mapper;

        public NftController(INftService nftService, IMapper mapper)
        {
            _nftService = nftService;
            _mapper = mapper;
        }

        //TODO: Add 401, 403 etc. codes to summary when auth will be added
        /// <summary>
        /// Returns all NFTs for user by user ID
        /// </summary>
        /// <remarks>
        /// User ID must be Guid
        /// </remarks>
        /// <param name="id">id</param>
        /// <response code="200">List of NFTs</response>
        [HttpGet("id")]
        public async Task<ActionResult<IEnumerable<NftResponse>>> GetNftByOwnerId(Guid id)
        {
            var nfts = await _nftService.GetNftsByOwnerIdAsync(id);

            var mapped = _mapper.Map<IEnumerable<NftResponse>>(nfts);

            return Ok(mapped);
        }

        /// <summary>
        /// Add new NFT
        /// </summary>
        /// <response code="200">Created NFT entity</response>
        /// <response code="400">Validation error</response>
        [HttpPost]
        public async Task<ActionResult<NftResponse>> AddNewNft(CreateNftRequest nft)
        {
            var mappedModel = _mapper.Map<NftModel>(nft);

            var createdNft = await _nftService.AddNewNftAsync(mappedModel);
            
            var mappedResponse = _mapper.Map<NftResponse>(createdNft);

            return Ok(mappedResponse);
        }

        /// <summary>
        /// Update NFT data
        /// </summary>
        /// <response code="204">NFT successfully updated</response>
        /// <response code="400">Validation error</response>
        [HttpPut]
        public async Task<ActionResult> UpdateNft(UpdateNftRequest nft)
        {
            var mappedModel = _mapper.Map<NftModel>(nft);

            await _nftService.UpdateNftAsync(mappedModel);

            return NoContent();
        }
    }
}
