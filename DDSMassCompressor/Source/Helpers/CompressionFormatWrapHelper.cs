using BCnEncoder.Shared;
using DDSMassCompressor.Source.Definitions;
using System;

namespace DDSMassCompressor.Source.Helpers
{
    internal static class CompressionFormatWrapHelper
    {
        public static CompressionFormat Convert(SupportedDXTFormat cf)
        {
            if (cf == SupportedDXTFormat.RGBA)
            {
                return CompressionFormat.Rgba;
            }
            else if (cf == SupportedDXTFormat.BC1_Alpha)
            {
                return CompressionFormat.Bc1WithAlpha;
            }
            else if (cf == SupportedDXTFormat.BC1)
            {
                return CompressionFormat.Bc1;
            }
            else if (cf == SupportedDXTFormat.BC2)
            {
                return CompressionFormat.Bc2;
            }
            else if (cf == SupportedDXTFormat.BC3)
            {
                return CompressionFormat.Bc3;
            }
            else if (cf == SupportedDXTFormat.BC4)
            {
                return CompressionFormat.Bc4;
            }
            else if (cf == SupportedDXTFormat.BC5)
            {
                return CompressionFormat.Bc5;
            }
            else
            {
                throw new NotSupportedException("Unknown format");
            }
        }
    }
}