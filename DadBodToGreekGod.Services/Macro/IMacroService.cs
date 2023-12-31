using DadBodToGreekGod.Models.Macro;

namespace DadBodToGreekGod.Services.Macro
{
    public interface IMacroService
    {
        Task<MacroDetail?> CreateMacroAsync(MacroCreate request);
        Task<IEnumerable<MacroDetail>> GetMacroByIdAsync();
        Task<bool> UpdateMacroAsync(MacroUpdate request, int userId);
        Task<bool> DeleteMacroAsync(int macroId);
    }
}