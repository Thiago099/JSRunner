# JSRunner

## Description

Allows you to write JS directly on your c# code

Example:

```c#
await js.Run("if(i % 10 == 0) alert(i)", new{ i });
```

You can also return a value:

```c#
i = await js.Run<int>(@"
i++
return i
", new{ i });
```



## Installation
Install this nuget package

On your program.cs add
```c#
using JSRunner;
```
[...]
```c#
builder.Services.AddJSRunner();
```

In your blazor component that you want to run js code add

```c#
@using JSRunner;
@inject JS js;
```
