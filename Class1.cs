#include <iostream>
#include <cstdlib> ///< Dla funkcji rand() i srand()
#include <ctime>   ///< Dla funkcji time()
using namespace std;

/**
 * @brief Struktura reprezentująca węzeł w liście dwukierunkowej.
 *
 * Węzeł zawiera dane oraz wskaźniki na poprzedni i następny węzeł.
 */
struct Node
{
    int data; ///< Wartość węzła
    Node* prev; ///< Wskaźnik na poprzedni węzeł
    Node* next; ///< Wskaźnik na następny węzeł

    /**
     * @brief Konstruktor węzła.
     * @param value Wartość, która będzie przechowywana w węźle
     */
    Node(int value) : data(value), prev(nullptr), next(nullptr) { }
};

/**
 * @brief Klasa reprezentująca listę dwukierunkową.
 *
 * Klasa obsługuje operacje dodawania, usuwania, wyświetlania i czyszczenia elementów listy.
 */
class DubleLinkedList
{
    private:
    Node* head; ///< Wskaźnik na pierwszy element listy
    Node* back; ///< Wskaźnik na ostatni element listy

    public:
    /**
     * @brief Konstruktor klasy, inicjalizujący pustą listę.
     *
     * Ustawia head i back na nullptr, ponieważ lista początkowo jest pusta. 
     * Inicjalizuje również generator liczb losowych.
     */
    DubleLinkedList() : head(nullptr), back(nullptr)
    {
        srand(static_cast<unsigned>(time(nullptr))); ///< Ustawia ziarno dla generatora liczb losowych
    }

    /**
     * @brief Dodaje losowy element na początek listy.
     *
     * Generuje losową wartość i tworzy nowy węzeł, który jest dodawany na początek listy.
     */
    void addRandomToHead()
    {
        int value = rand() % 100; ///< Losuje wartość w zakresie 0-99
        Node* newNode = new Node(value); ///< Tworzy nowy węzeł o wygenerowanej wartości
        if (!head)
        {
            head = back = newNode; ///< Ustawia head i back na newNode, jeśli lista jest pusta
        }
        else
        {
            newNode->next = head; ///< Nowy węzeł staje się nową głową
            head->prev = newNode; ///< Wskaźnik prev starej głowy wskazuje na nowy węzeł
            head = newNode; ///< Ustawia nowy węzeł jako head
        }
    }

    /**
     * @brief Dodaje losowy element na koniec listy.
     *
     * Generuje losową wartość i tworzy nowy węzeł, który jest dodawany na koniec listy.
     */
    void addRandomToBack()
    {
        int value = rand() % 100; ///< Losuje wartość w zakresie 0-99
        Node* newNode = new Node(value); ///< Tworzy nowy węzeł o wygenerowanej wartości
        if (!back)
        {
            head = back = newNode; ///< Ustawia head i back na newNode, jeśli lista jest pusta
        }
        else
        {
            newNode->prev = back; ///< Nowy węzeł staje się nowym ostatnim elementem
            back->next = newNode; ///< Wskaźnik next starego ostatniego elementu wskazuje na nowy węzeł
            back = newNode; ///< Ustawia nowy węzeł jako back
        }
    }

    /**
     * @brief Wstawia losowy element pod wskazany indeks.
     *
     * Generuje losową wartość i wstawia nowy węzeł w odpowiednim miejscu w liście.
     * @param index Indeks, pod którym ma być wstawiony nowy element
     */
    void insertRandomAt(int index)
    {
        int value = rand() % 100; ///< Losuje wartość w zakresie 0-99
        if (index == 0)
        {
            addRandomToHead(); ///< Dodaje element na początek listy
            return;
        }

        Node* current = head;
        int pos = 0;
        while (current && pos < index - 1)
        { ///< Szuka węzła na pozycji index - 1
            current = current->next;
            pos++;
        }

        if (!current)
        {
            cout << "Indeks poza zakresem" << endl; ///< Indeks jest poza zakresem
            return;
        }

        Node* newNode = new Node(value);
        newNode->next = current->next; ///< Ustawia wskaźniki nowego węzła
        newNode->prev = current;

        if (current->next)
        {
            current->next->prev = newNode; ///< Ustawia wskaźnik prev następnego węzła
        }
        else
        {
            back = newNode; ///< Ustawia nowy węzeł jako back, jeśli jest ostatni
        }

        current->next = newNode; ///< Ustawia wskaźnik next dla węzła na nowy węzeł
    }

    /**
     * @brief Usuwa element z początku listy.
     *
     * Sprawdza, czy lista nie jest pusta, a następnie usuwa pierwszy element.
     */
    void removeFromHead()
    {
        if (!head) return; ///< Sprawdza, czy lista nie jest pusta
        Node* temp = head;
        head = head->next; ///< Ustawia head na następny węzeł
        if (head)
        {
            head->prev = nullptr; ///< Ustawia wskaźnik prev na nullptr
        }
        else
        {
            back = nullptr; ///< Ustawia back na nullptr, jeśli lista jest pusta
        }
        delete temp; ///< Usuwa stary węzeł
    }

    /**
     * @brief Usuwa element z końca listy.
     *
     * Sprawdza, czy lista nie jest pusta, a następnie usuwa ostatni element.
     */
    void removeFromBack()
    {
        if (!back) return; ///< Sprawdza, czy lista nie jest pusta
        Node* temp = back;
        back = back->prev; ///< Ustawia back na poprzedni węzeł
        if (back)
        {
            back->next = nullptr; ///< Ustawia wskaźnik next na nullptr
        }
        else
        {
            head = nullptr; ///< Ustawia head na nullptr, jeśli lista jest pusta
        }
        delete temp; ///< Usuwa stary węzeł
    }

    /**
     * @brief Usuwa element pod danym indeksem.
     *
     * Sprawdza, czy indeks jest poprawny, a następnie usuwa odpowiedni element.
     * @param index Indeks elementu do usunięcia
     */
    void removeAt(int index)
    {
        if (index == 0)
        {
            removeFromHead(); ///< Usuwa element z początku listy
            return;
        }

        Node* current = head;
        int pos = 0;
        while (current && pos < index)
        { ///< Szuka węzła na podanym indeksie
            current = current->next;
            pos++;
        }

        if (!current)
        {
            cout << "Indeks poza zakresem" << endl; ///< Indeks jest poza zakresem
            return;
        }

        if (current->prev) current->prev->next = current->next; ///< Dostosowuje wskaźniki sąsiednich węzłów
        if (current->next) current->next->prev = current->prev;

        if (current == back) back = current->prev; ///< Aktualizuje wskaźnik back, jeśli usuwany element to back

        delete current; ///< Usuwa węzeł
    }

    /**
     * @brief Wyświetla całą listę.
     *
     * Przechodzi przez listę i wyświetla dane dla każdego elementu.
     */
    void display()
    {
        Node* current = head; ///< Przechodzi przez listę od head do back
        while (current)
        {
            cout << current->data << " ";
            current = current->next;
        }
        cout << endl;
    }

    /**
     * @brief Wyświetla listę w odwrotnej kolejności.
     *
     * Przechodzi przez listę od back do head i wyświetla dane dla każdego elementu.
     */
    void displayReverse()
    {
        Node* current = back;
        while (current)
        {
            cout << current->data << " "; ///< Wyświetla dane w odwrotnej kolejności
            current = current->prev;
        }
        cout << endl;
    }

    /**
     * @brief Czyści całą listę.
     *
     * Usuwa wszystkie elementy z listy, używając metody removeFromHead().
     */
    void clear()
    {
        while (head)
        {
            removeFromHead(); ///< Usuwa każdy element zaczynając od początku
        }
    }

    /**
     * @brief Destruktor, który automatycznie wywołuje funkcję czyszczącą.
     */
    ~DubleLinkedList()
    {
        clear(); ///< Czyści listę przy wywołaniu destruktora
    }
};

/**
 * @brief Funkcja główna.
 *
 * Tworzy nową listę dwukierunkową, dodaje do niej losowe elementy, a następnie wykonuje różne operacje na liście.
 * Na końcu wyświetla stan listy po wykonaniu operacji.
 */
int main()
{
    DubleLinkedList list; ///< Tworzy nową listę dwukierunkową o nazwie list

    list.addRandomToHead(); ///< Dodaje losowy element na początek listy
    list.addRandomToHead(); ///< Dodaje kolejny losowy element na początek listy
    list.addRandomToBack(); ///< Dodaje losowy element na koniec listy
    list.insertRandomAt(1); ///< Wstawia nowy element pomiędzy początkiem listy a drugim elementem

    cout << "Lista z losowymi wartościami: ";
    list.display(); ///< Wyświetla wszystkie elementy

    cout << "Lista w odwrotnej kolejności: ";
    list.displayReverse(); ///< Wyświetla listę w odwrotnej kolejności

    list.removeFromHead(); ///< Usuwa początkowy element listy
    list.removeFromBack(); ///< Usuwa końcowy element listy
    list.removeAt(0); ///< Usuwa element pod wskazanym indeksem

    cout << "Lista po usunięciu elementów: ";
    list.display(); ///< Wyświetla pozostałe elementy po usunięciach

    list.clear(); ///< Czyści listę
    cout << "Lista po wyczyszczeniu: ";
    list.display(); ///< Wyświetla listę po usunięciu

    return 0;
}
