using UnityEngine;

public class DuckInfo : MonoBehaviour
{
    // para pular uma linha dentro da string basta usar \n
    // Exemplo: "Pato 1: Eu sou um pato.\nQue legal!"

    // O texto ficaria assim:

    // Pato 1: Eu sou um pato
    // Que Legal!

    private string[] duckMessages = new string[]
    {
        "   No Brasil, mais de 6 milhões de pessoas, aproximadamente, têm algum tipo de deficiência visual, segundo dados do Censo de 2010 realizado pelo IBGE. Destas, mais de 500 mil são cegas, enquanto o restante possui baixa visão ou algum nível de deficiência visual parcial. \n\n     Essas informações são importantes para a formulação de políticas públicas de acessibilidade e inclusão, visando proporcionar maior acessibilidade, especialmente em áreas como educação, transporte  e serviços digitais.",
        "   As principais causas de cegueira incluem doenças oculares, fatores genéticos, traumas, e complicações de outras condições médicas. As mais comuns são:\n\n   Catarata:  É uma das principais causas de cegueira reversível e pode ser tratada com cirurgia.\n\n    Glaucoma: Muitas vezes assintomático em estágios iniciais, o que dificulta o diagnóstico precoce.\n\n Degeneração macular relacionada à idade (DMRI):  Comum em idosos e geralmente irreversível.\n\n   Retinopatia diabética: Resulta do diabetes mal controlado, causando danos aos vasos sanguíneos da retina. \n\n    Outras doenças e fatores incluem: ceratocone, infecções, doenças congênitas, doenças hereditárias, traumas e lesões oculares.  \n\n   A prevenção e o diagnóstico precoce de algumas dessas condições são fundamentais para evitar a cegueira ou reduzir seu impacto na qualidade de vida.",
        "   Acessibilidade: \n\n    Leitores de Tela \n\n   Programas que leem o conteúdo da tela em voz alta, permitindo que pessoas com deficiência visual naveguem em computadores, smartphones e tablets.\n\n   Exemplos:\r\nJAWS (Job Access With Speech): Popular no Windows, usado principalmente no ambiente profissional e acadêmico. Converte texto em áudio e tem comandos para navegação eficiente.\n\n VoiceOver: Disponível em dispositivos da Apple (iPhone, iPad, Mac). Permite que usuários naveguem pelas telas usando gestos, possibilitando fácil acesso aos aplicativos.\n\n   NVDA (NonVisual Desktop Access): Um software gratuito para Windows, amplamente usado por sua acessibilidade e eficiência.",
        "   Acessibilidade: \n\n    Sistema Braile e a importância da Leitura Tátil\n\n O sistema braille é uma forma de escrita tátil que utiliza pontos em relevo para representar letras, números e símbolos sendo uma ferramenta essencial para a alfabetização e o acesso à informação por pessoas cegas ou com baixa visão.\n\n   Importância do Braille:\n\n O braille não é apenas uma forma de leitura; ele proporciona contato direto com a estrutura e ortografia da língua, algo fundamental para o desenvolvimento da alfabetização.  Além disso, o braille é indispensável para que as pessoas possam ler textos em silêncio, aprender a ortografia correta e desenvolver uma compreensão completa da estrutura das palavras.\nExemplos de Uso: Rótulos, embalagens, livros, publicações, material escolar e acadêmico.",
        "   Acessibilidade: \n\n    Dispositivos de Leitura com Câmera OCR (Reconhecimento Óptico de Caracteres)\n\n    Descrição: Dispositivos portáteis com câmeras que capturam imagens de texto impresso e as convertem em áudio. Eles ajudam no dia-a-dia em uma biblioteca ou supermercado, por exemplo, a pessoa pode usar o dispositivo para ler um livro ou verificar ingredientes e informações nutricionais em produtos.\n\n Exemplos:\n\n   OrCam MyEye: Dispositivo portátil que pode ser acoplado a óculos. Ele captura textos, identifica rostos e lê códigos de barras, transformando em áudio.\n\n KNFB Reader: Aplicativo para smartphones que tira fotos de textos impressos e os converte para áudio instantaneamente.",
        "   Acessibilidade: \n\n    Mapas Táteis e Piso tátil \n\n  Mapas e pisos com texturas especiais que permitem que pessoas cegas se orientem e se desloquem de forma segura em ambientes públicos, garantindo mais independência e segurança. \n\n   Exemplos: \n\n  Piso Tátil (podotátil): Pisos com texturas distintas (linhas e pontos) que servem como guia em áreas de grande circulação, como estações de transporte e calçadas. \n\n Mapas Táteis: Mapas em relevo ou braille para que pessoas cegas possam identificar a disposição de espaços públicos, como shoppings, universidades e hospitais.",
        "   Acessibilidade: \n\n    Tecnologia de Assistência por Inteligência Artificial \n\n  Aplicativos que utilizam IA para descrever o ambiente, identificar objetos e até reconhecer rostos, auxiliando no cotidiano, tornando o dia a dia de pessoas com deficiência visual mais interativo e seguro. \n\n  Exemplos: \n\n  Seeing AI: Aplicativo da Microsoft que identifica objetos, descreve cenas, reconhece textos e até rostos conhecidos, proporcionando uma experiência de leitura e interação com o ambiente. \n\n Be My Eyes: Conecta pessoas cegas com voluntários videntes via chamada de vídeo, onde o voluntário pode descrever o ambiente ou identificar objetos e situações que o usuário necessita.",
        "   Acessibilidade: \n\n    Audiodescrição em Vídeos e Espetáculos \n\n Narração adicional que descreve elementos visuais importantes em filmes, programas, peças de teatro e eventos ao vivo, proporcionando uma experiência que pessoas cegas possam aproveitar conteúdos audiovisuais com a mesma riqueza de detalhes.\n\n   Exemplos:\n\n   Streaming com audiodescrição: Plataformas como Netflix e Amazon Prime oferecem audiodescrição para vários filmes e séries, descrevendo as cenas e ações para que pessoas cegas possam compreender o conteúdo visual.\n\n    Teatros e eventos ao vivo: Cada vez mais, teatros oferecem audiodescrição durante espetáculos, permitindo que pessoas com deficiência visual participem plenamente da experiência.",
    };

    public int duckIndex;

    public string GetInfoMessage()
    {
        if (duckIndex >= 0 && duckIndex < duckMessages.Length)
        {
            return duckMessages[duckIndex];
        }
        Debug.Log($"Índice inválido ou fora do limite: {duckIndex}");
        return "Mensagem padrão de coleta de pato!";
    }
}