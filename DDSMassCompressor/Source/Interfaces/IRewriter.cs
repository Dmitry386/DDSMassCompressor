using System.Threading.Tasks;

namespace DDSMassCompressor.Source.Interfaces
{
    internal interface IRewriter
    {
        public float Progress { get; set; }
        public Task HandleDirectory();
    }
}