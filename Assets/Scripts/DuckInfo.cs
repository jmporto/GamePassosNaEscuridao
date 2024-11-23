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
        "   No Brasil, mais de 6 milh�es de pessoas, aproximadamente, t�m algum tipo de defici�ncia visual, segundo dados do Censo de 2010 realizado pelo IBGE. Destas, mais de 500 mil s�o cegas, enquanto o restante possui baixa vis�o ou algum n�vel de defici�ncia visual parcial. \n\n     Essas informa��es s�o importantes para a formula��o de pol�ticas p�blicas de acessibilidade e inclus�o, visando proporcionar maior acessibilidade, especialmente em �reas como educa��o, transporte  e servi�os digitais.",
        "   As principais causas de cegueira incluem doen�as oculares, fatores gen�ticos, traumas, e complica��es de outras condi��es m�dicas. As mais comuns s�o:\n\n   Catarata:  � uma das principais causas de cegueira revers�vel e pode ser tratada com cirurgia.\n\n    Glaucoma: Muitas vezes assintom�tico em est�gios iniciais, o que dificulta o diagn�stico precoce.\n\n Degenera��o macular relacionada � idade (DMRI):  Comum em idosos e geralmente irrevers�vel.\n\n   Retinopatia diab�tica: Resulta do diabetes mal controlado, causando danos aos vasos sangu�neos da retina. \n\n    Outras doen�as e fatores incluem: ceratocone, infec��es, doen�as cong�nitas, doen�as heredit�rias, traumas e les�es oculares.  \n\n   A preven��o e o diagn�stico precoce de algumas dessas condi��es s�o fundamentais para evitar a cegueira ou reduzir seu impacto na qualidade de vida.",
        "   Acessibilidade: \n\n    Leitores de Tela \n\n   Programas que leem o conte�do da tela em voz alta, permitindo que pessoas com defici�ncia visual naveguem em computadores, smartphones e tablets.\n\n   Exemplos:\r\nJAWS (Job Access With Speech): Popular no Windows, usado principalmente no ambiente profissional e acad�mico. Converte texto em �udio e tem comandos para navega��o eficiente.\n\n VoiceOver: Dispon�vel em dispositivos da Apple (iPhone, iPad, Mac). Permite que usu�rios naveguem pelas telas usando gestos, possibilitando f�cil acesso aos aplicativos.\n\n   NVDA (NonVisual Desktop Access): Um software gratuito para Windows, amplamente usado por sua acessibilidade e efici�ncia.",
        "   Acessibilidade: \n\n    Sistema Braile e a import�ncia da Leitura T�til\n\n O sistema braille � uma forma de escrita t�til que utiliza pontos em relevo para representar letras, n�meros e s�mbolos sendo uma ferramenta essencial para a alfabetiza��o e o acesso � informa��o por pessoas cegas ou com baixa vis�o.\n\n   Import�ncia do Braille:\n\n O braille n�o � apenas uma forma de leitura; ele proporciona contato direto com a estrutura e ortografia da l�ngua, algo fundamental para o desenvolvimento da alfabetiza��o.  Al�m disso, o braille � indispens�vel para que as pessoas possam ler textos em sil�ncio, aprender a ortografia correta e desenvolver uma compreens�o completa da estrutura das palavras.\nExemplos de Uso: R�tulos, embalagens, livros, publica��es, material escolar e acad�mico.",
        "   Acessibilidade: \n\n    Dispositivos de Leitura com C�mera OCR (Reconhecimento �ptico de Caracteres)\n\n    Descri��o: Dispositivos port�teis com c�meras que capturam imagens de texto impresso e as convertem em �udio. Eles ajudam no dia-a-dia em uma biblioteca ou supermercado, por exemplo, a pessoa pode usar o dispositivo para ler um livro ou verificar ingredientes e informa��es nutricionais em produtos.\n\n Exemplos:\n\n   OrCam MyEye: Dispositivo port�til que pode ser acoplado a �culos. Ele captura textos, identifica rostos e l� c�digos de barras, transformando em �udio.\n\n KNFB Reader: Aplicativo para smartphones que tira fotos de textos impressos e os converte para �udio instantaneamente.",
        "   Acessibilidade: \n\n    Mapas T�teis e Piso t�til \n\n  Mapas e pisos com texturas especiais que permitem que pessoas cegas se orientem e se desloquem de forma segura em ambientes p�blicos, garantindo mais independ�ncia e seguran�a. \n\n   Exemplos: \n\n  Piso T�til (podot�til): Pisos com texturas distintas (linhas e pontos) que servem como guia em �reas de grande circula��o, como esta��es de transporte e cal�adas. \n\n Mapas T�teis: Mapas em relevo ou braille para que pessoas cegas possam identificar a disposi��o de espa�os p�blicos, como shoppings, universidades e hospitais.",
        "   Acessibilidade: \n\n    Tecnologia de Assist�ncia por Intelig�ncia Artificial \n\n  Aplicativos que utilizam IA para descrever o ambiente, identificar objetos e at� reconhecer rostos, auxiliando no cotidiano, tornando o dia a dia de pessoas com defici�ncia visual mais interativo e seguro. \n\n  Exemplos: \n\n  Seeing AI: Aplicativo da Microsoft que identifica objetos, descreve cenas, reconhece textos e at� rostos conhecidos, proporcionando uma experi�ncia de leitura e intera��o com o ambiente. \n\n Be My Eyes: Conecta pessoas cegas com volunt�rios videntes via chamada de v�deo, onde o volunt�rio pode descrever o ambiente ou identificar objetos e situa��es que o usu�rio necessita.",
        "   Acessibilidade: \n\n    Audiodescri��o em V�deos e Espet�culos \n\n Narra��o adicional que descreve elementos visuais importantes em filmes, programas, pe�as de teatro e eventos ao vivo, proporcionando uma experi�ncia que pessoas cegas possam aproveitar conte�dos audiovisuais com a mesma riqueza de detalhes.\n\n   Exemplos:\n\n   Streaming com audiodescri��o: Plataformas como Netflix e Amazon Prime oferecem audiodescri��o para v�rios filmes e s�ries, descrevendo as cenas e a��es para que pessoas cegas possam compreender o conte�do visual.\n\n    Teatros e eventos ao vivo: Cada vez mais, teatros oferecem audiodescri��o durante espet�culos, permitindo que pessoas com defici�ncia visual participem plenamente da experi�ncia.",
    };

    public int duckIndex;

    public string GetInfoMessage()
    {
        if (duckIndex >= 0 && duckIndex < duckMessages.Length)
        {
            return duckMessages[duckIndex];
        }
        Debug.Log($"�ndice inv�lido ou fora do limite: {duckIndex}");
        return "Mensagem padr�o de coleta de pato!";
    }
}