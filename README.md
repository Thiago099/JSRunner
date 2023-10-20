# JSRunner

## Description

Allows you to write js directally on your c# code

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

install this nutget package

on your program.cs add
```c#
using JSRunner;
```
[...]
```c#
builder.Services.AddJSRunner();
```

on your blazor component that you want to run js code add

```c#
@using JSRunner;
@inject JS js;
```
