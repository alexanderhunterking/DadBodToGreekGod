using DadBodToGreekGod.Models.Macro;

namespace DadBodToGreekGod.Services.Macro
{
    public interface IMacroService
    {
        Task<MacroDetail?> CreateMacroAsync(MacroCreate request);
        Task<MacroDetail?> GetMacroByIdAsync(int userId);
        Task<bool> UpdateMacroAsync(MacroUpdate request);
        Task<bool> DeleteMacroAsync(int macroId);
    }
}