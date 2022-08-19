using meli_mutations.Core.Resolver;
using Xunit;

namespace meli_test;

public class HashResovlerTest
{
    [Fact]
    public void WhenHashIsDefined()
    {
        Assert.Equal("c42340e907cef3033ee847f197d650de62d954a359d560c5337246b0fcabe4740c8c8eecdbddbfc98b626d76ae61540802869e35154a15b8a07d2bf13499f4d7".ToUpper(), HashResolver.Resolve("MeliTest"));
    }

    [Fact]
    public void WhenHashIsLarge()
    {
        Assert.Equal("c42340e907cef3033ee847f197d650de62d954a359d560c5337246b0fcabe4740c8c8eecdbddbfc98b626d76ae61540802869e35154a15b8a07d2bf13499f4d7".ToUpper(), HashResolver.Resolve("MeliTest"));
    }
}