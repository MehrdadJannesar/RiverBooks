﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FastEndpoints.Testing;
using Xunit.Abstractions;

namespace RiverBook.Books.Tests.Endpoints;
public class Fixture(IMessageSink messageSink):TestFixture<Program>(messageSink)
{
  protected override Task SetupAsync()
  {
    Client = CreateClient();
    return Task.CompletedTask;
  }
  protected override Task TearDownAsync()
  {
    Client.Dispose();
    return base.TearDownAsync();
  }
}
