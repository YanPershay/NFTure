using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using NFTure.Application;
using NFTure.Web.Controllers.Base;
using NFTure.Web.DTOs;

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

        /// <summary>
        /// Returns all NFTs for user by user ID
        /// </summary>
        /// <remarks>
        /// User ID must be Guid
        /// </remarks>
        /// <param name="id">id</param>
        /// <response code="200">List of NFTs</response>
        [HttpGet("id")]
        public async Task<ActionResult<IEnumerable<NftDto>>> GetNftByOwnerId(Guid id)
        {
            var nfts = await _nftService.GetNftsByOwnerIdAsync(id);

            var mapped = _mapper.Map<IEnumerable<NftDto>>(nfts);

            return Ok(mapped);
        }
    }
}
