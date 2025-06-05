using CFour.Entities.System;

namespace CFour.Helpers.Match;

internal static class SystemSpecificationHelpers
{
    /// <summary>
    /// Converts the system specification details into a formatted string of prompts and appends them to the provided prompts list.
    /// </summary>
    /// <param name="systemSpecification">
    /// The system specification object containing details such as processor, memory, storage, GPU, operating system, and display.
    /// </param>
    /// <param name="prompts">
    /// A list of strings to which the generated system specification prompts will be added.
    /// </param>
    /// <returns>
    /// A single string containing the formatted system specification prompts separated by newline characters.
    /// </returns>
    internal static string ToPrompts(this SystemSpecification systemSpecification, List<string> prompts)
    {
        var processor = systemSpecification.Processor;
        var memory = systemSpecification.Memory;
        var storage = systemSpecification.Storage;
        var gpu = systemSpecification.Gpu;
        var operationSystem = systemSpecification.OperationSystem;
        var display = systemSpecification.Display;
        
        List<string> systemSpecificationPrompts =
        [
            "Processor:",
            $"- Name: {processor.Name}",
            $"- Total Cores: {processor.Cores}",
            $"- Threads: {processor.Threads}",
            $"- Base Clock Speed: {processor.BaseClockSpeedGHz} GHz",
            $"- Turbo Clock Speed: {processor.TurboClockGHz} GHz",
            "Memory:",
            $"- RAM: {memory.RamTotalMb} MB",
            $"- GRAM: {memory.VRamTotalMb} MB",
            "Storage:",
            $"- Available Space: {storage.AvailableMb} MB",
            $"- Type: {storage.Type}",
            "GPU:",
            $"- Model: {gpu.Model}",
            $"- Memory: {gpu.MemoryGb} GB",
            "Operating System:",
            $"- Type: {operationSystem.Type}",
            $"- Version: {operationSystem.Version}",
            $"- Architecture: {operationSystem.Architecture}",
            "Display:",
            $"- Resolution: {display.Width}x{display.Height}",
            $"- Refresh Rate: {display.MonitorRefreshRateHz} Hz",
            $"- Machine Type: {(systemSpecification.IsLaptop ? "Laptop" : "Desktop")}"
        ];

        prompts.AddRange(systemSpecificationPrompts);

        return string.Join('\n', systemSpecificationPrompts);
    }
}