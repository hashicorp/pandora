// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Hosting;

namespace Pandora.Api;

public class Program
{
    public static void Main(string[] args)
    {
        CreateHostBuilder(args).Build().Run();
    }

    public static IHostBuilder CreateHostBuilder(string[] args) =>
        Host.CreateDefaultBuilder(args)
            .ConfigureWebHostDefaults(webBuilder => { webBuilder.UseStartup<Startup>(); });
}