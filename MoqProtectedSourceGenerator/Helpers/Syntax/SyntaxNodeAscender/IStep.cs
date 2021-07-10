﻿using System;
using Microsoft.CodeAnalysis;

namespace MoqProtectedSourceGenerator
{
    public interface IStep<in TContext>
    {
        Type ExpectedNodeType { get; set; }
        void Execute(TContext context, SyntaxNode node);
    }
}
