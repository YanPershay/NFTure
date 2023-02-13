using System.ComponentModel;

namespace NFTure.Core
{
    public enum UserActivityAction
    {
        [Description("Added new NFT")]
        AddedNewNft,

        [Description("NFT was updated")]
        NftUpdated,

        [Description("NFT was deleted")]
        NftDeleted
    }
}
