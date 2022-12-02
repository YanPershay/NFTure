using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using NFTure.Application;
using NFTure.Web.Controllers.Base;
using NFTure.Web.DTOs;

namespace NFTure.Web.Controllers
{
    // TODO: settings for mapper and logger
    public class NftController : ApiController
    {
        private readonly INftService _nftService;
        //private readonly IMapper _mapper;

        public NftController(INftService nftService/*, IMapper mapper*/)
        {
            _nftService = nftService;
            //_mapper = mapper;
        }

        [HttpGet]
        public ActionResult GetMessage() => Ok("Asalam aleikum");

        [HttpGet("id")]
        public async Task<ActionResult<IEnumerable<NftDto>>> GetNftByOwnerId(Guid id)
        {
            var nfts = await _nftService.GetNftsByOwnerIdAsync(id);
            return Ok();
            //var mapped = _mapper.Map<IEnumerable<NftDto>>(nfts);

            //return Ok(mapped);
        }
    }
}
