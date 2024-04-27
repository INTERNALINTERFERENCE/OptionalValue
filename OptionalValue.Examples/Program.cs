// See https://aka.ms/new-console-template for more information

using System;
using OptionalValue;

var example = new Example
{
    ExampleProperty1 = null
};

var ep1HasValue = example.ExampleProperty1.HasValue;
var ep2HasValue = example.ExampleProperty2.HasValue;

Console.WriteLine(string.Join(',', ep1HasValue, ep2HasValue));

internal class Example
{
    public OptionalValue<string> ExampleProperty1 { get; init; }
    public OptionalValue<int> ExampleProperty2 { get; init; }
}