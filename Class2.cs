﻿%╔════════════════════════════╗
%║	  Szablon dostosował	  ║
%║	mgr inż. Dawid Kotlarski  ║
%║		  06.10.2024		  ║
%╚════════════════════════════╝
\documentclass[12pt, twoside, a4paper, openany] { article}

\input{preambula_pakiety.tex}
\input{preambula_ustawienia.tex}

% polecenia zdefiniowane w pakiecie strona_tytulowa.sty
\title{...Algorytm listy dwukierunkowej \\z zastosowaniem GitHub...}		% ...Wpisać nazwę projektu...
\author{Imie Nazwisko}
\authorI{}
\authorII{}		% jeśli są dwie osoby w projekcie to zostawiamy:    \authorII{}

\uczelnia{AKADEMIA NAUK STOSOWANYCH \\W NOWYM SĄCZU}
\instytut{Wydział Nauk Inżynieryjnych}
\kierunek{Katedra Informatyki}
\praca{DOKUMENTACJA PROJEKTOWA}
\przedmiot{ZAAWANSOWANE PROGRAMOWANIE}
\prowadzacy{mgr inż. Dawid Kotlarski}
\rok{2024}

% definicja składni mikrotik
\usepackage{fancyvrb}
\DefineVerbatimEnvironment{MT}{ Verbatim}%
{ commandchars =\+\[\],fontsize =\small,formatcom =\color{ red},frame = lines,baselinestretch = 1,} 
\let\mt\verb 
%zakonczenie definicji składni mikrotik

\usepackage{fancyhdr}    % biblioteka do nagłówka i stopki

\begin{document}
   
\renewcommand{\figurename}{ Rys.}    % musi byc pod \begin{document}, bo w~tym miejscu pakiet 'babel' narzuca swoje ustawienia
\renewcommand{\tablename}{ Tab.}     % j.w.
\thispagestyle{empty}               % na tej stronie: brak numeru
\stronatytulowa                     %strona tytułowa tworzona przez pakiet strona_tytulowa.tex

\pagestyle{fancy}

\newpage

% formatowanie spisu treści i~nagłówków
\renewcommand{\cftbeforesecskip}{ 8pt}
\renewcommand{\cftsecafterpnum}{\vskip 8pt}
\renewcommand{\cftparskip}{ 3pt}
\renewcommand{\cfttoctitlefont}{\Large\bfseries\sffamily}
\renewcommand{\cftsecfont}{\bfseries\sffamily}
\renewcommand{\cftsubsecfont}{\sffamily}
\renewcommand{\cftsubsubsecfont}{\sffamily}
\renewcommand{\cftparafont}{\sffamily}
% koniec formatowania spisu treści i nagłówków

\tableofcontents    %spis treści
\thispagestyle{fancy}
\newpage

% Wprowadzenie do Doxygen
\section{Dokumentacja Doxygen}
Doxygen to narzędzie do generowania dokumentacji z kodu źródłowego. W projekcie, który rozważamy, klasa \texttt{DubleLinkedList} oraz jej metody zostały opatrzone komentarzami Doxygen, które pozwalają na automatyczne generowanie dokumentacji w formacie HTML, LaTeX, PDF i wielu innych.

\subsection{Przykładowy kod}
Poniżej przedstawiamy przykładowy kod źródłowy z zastosowaniem Doxygen:
\begin{verbatim}
#include <iostream>
#include <cstdlib>
#include <ctime>
using namespace std;

// Komentarze Doxygen dla struktury Node
struct Node
{
    int data; ///< Wartość węzła
    Node* prev; ///< Wskaźnik na poprzedni węzeł
    Node* next; ///< Wskaźnik na następny węzeł

    Node(int value) : data(value), prev(nullptr), next(nullptr) { }
};

// Komentarze Doxygen dla klasy DubleLinkedList
class DubleLinkedList
{
    private:
    Node* head; ///< Wskaźnik na pierwszy element listy
    Node* back; ///< Wskaźnik na ostatni element listy

    public:
    DubleLinkedList() : head(nullptr), back(nullptr)
    {
        srand(static_cast<unsigned>(time(nullptr)));
    }

    // Metody klasy...
};
\end{verbatim}

\newpage

%%%%%%%%%%%%%%%%%%% treść główna dokumentu %%%%%%%%%%%%%%%%%%%%%%%%%

\input{tex/rozdzial1.tex}
\input{tex/rozdzial2.tex}
\input{tex/rozdzial3.tex}
\input{tex/rozdzial4.tex}
\input{tex/rozdzial5.tex}

%%%%%%%%%%%%%%%%%%% koniec treść główna dokumentu %%%%%%%%%%%%%%%%%%%%%
\newpage
\addcontentsline{toc}{ section}
{ Literatura}  
\printbibliography

\newpage
\hypersetup{linkcolor=black}
\renewcommand{\cftparskip}{ 3pt}
\clearpage
\renewcommand{\cftloftitlefont}{\Large\bfseries\sffamily}
\listoffigures
\addcontentsline{toc}{ section}
{ Spis rysunków}
\thispagestyle{fancy}

\newpage
\renewcommand{\cftlottitlefont}{\Large\bfseries\sffamily}
\def\listtablename{Spis tabel}
\addcontentsline{toc}{ section}
{ Spis tabel}\listoftables
\thispagestyle{fancy}

\newpage
\renewcommand{\cftlottitlefont}{\Large\bfseries\sffamily}
\renewcommand\lstlistlistingname{Spis listingów}
\addcontentsline{toc}{ section}
{ Spis listingów}\lstlistoflistings
\thispagestyle{fancy}

% lista rzeczy do zrobienia: wypisuje na koñcu dokumentu, patrz: pakiet todo.sty
\todos
%koniec listy rzeczy do zrobienia
\end{document}
