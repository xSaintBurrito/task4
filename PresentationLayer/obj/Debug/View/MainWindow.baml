   M S B A M L   `   `   `  ����L  HPresentationLayer, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null5clr-namespace:PresentationLayerPresentationLayer  5   	   "    PresentationLayer.MainWindow   5   	   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   1localclr-namespace:PresentationLayer     5   	     � Title$  Library��5      $	��450��6   $	��800��6)   $	��450��69   $	��800��6F   .��5
      ��  �� Padding$ 10q�6   
����·�._�5   
   � .+�5      �� .+�5      �� -   5         ��Name$ 	ErrorText��5      $�� ��6/   $
��Bold"�67   
����·�6I   � 5       � ColumnDefinitions 5      �� 5      $��2* �6+   �� 5      $��5* �6+   .+�5      �� $��0��6!   .+�5      � .+�5      �� .+�5   "   �� -   5        $ ControlsText��5   ,   $��Managing Data��6B   $
��Bold"�6W   $��10 10 10 10q�6i   �� 5   "   -   5         ��Name$ 	AddButton��5   )   $��	10 5 10 5q�6T   $	��Add��6g   �� 5   "   -   5        $ RentBookButton��5   )   $��	10 0 10 5q�6^   $��	Rent Book��6q   �� 5   "   -   5        $ ReturnBookButton��5   )   $��	10 0 10 5q�6b   $��Return Book��6u   �� 5   "   -   5        $ RemoveButton��5   )   $��	10 2 10 5q�6Z   $��Remove��6m   �� 5   "   -   5        $ RemoveAllButton��5   )   $��	10 0 10 2q�6`   $��
Remove All��6s   5      5      �� 5       $��Available lists��6$   $
��Bold"�6;   $��
10 70 0 10q�6M   � 5!      .+�5"      �� .+�5#   "   �� -   5        $ BooksButton��5#   )   $��	10 0 10 5q�6X   $��Books��6k   �� 5$   "   -	   5        $ ClientsButton��5$   )   $��	10 0 10 5q�6\   $��Clients��6o   �� 5%   "   -
   5        $ RentsButton��5%   )   $��	10 0 10 5q�6X   $��Rents��6k   5&      5'      5(      �� 5*      $��1��6!   .+�5+      �� -   5        $��DataContextTitle��5+       $
��18px(�68   $��DemiBold"�6H   $��Center=�6^   $	��Top=�6�   $��
30,00,40,0q�6�   $��40��6�   �� 5,      -   5        $��DataContextContainer��5,   "   $
��Left=�6w   $	��Top=�6�   $��	30,0,30,0q�6�   $	��480��6�   $	��300��6�   $
��Auto��6�   $
��Auto��6�   5-      5/      50      51      52      53      