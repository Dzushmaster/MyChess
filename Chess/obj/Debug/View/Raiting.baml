   M S B A M L   `   `   `  ����@  <Chess, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null'clr-namespace:Chess.View
Chess.View  5          Chess.View.Raiting   5      \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      *localclr-namespace:Chess.View     5        N� Title$  Raiting��5	       � 	Resources 5
       �� 
TargetType   ButtonWithText �� Property �� Value  ButtonWithImage��%8  &	        &	 �     �� 5   
   " ��6   .�5      ��  � ��$ 35(�6)   �� 5       � ��$ 5,0,0,0q�6'   �� 5       � ��$ 0q�60   �� 5       � ��
 �����6+   5      �� 5   
   " ��6   .�5      ��  � ��$ 3q�6'   �� 5       � ��$ 0q�60   5      5      .��5      � 
���   � � RowDefinitions 5   
   �� 5      $
��1.2* �6   �� 5      $��1* �6   �� 5      $��6* �6   .+�5   
   �� -   5         ��Name$ Return��5      $
��Home��6!   #��[ 6_   $
��Left=�6�   $��Center=�6�   ��69   ��  �� Path$ 
SelectPage�.��5      �� $&�� D:\COURSE_PROJECT\Image\Left.png��6   5      �� 5   
    �� Orientation$ 
Horizontal=�6   $��Right=�6.   $��Center=�6J   .+�5       �� -   5        $ 
DeleteUser��5       #��[ 6)   ��6R   �� 	 �� ElementName$	 Return��$ ActualHeight�.��5!      �� $'��!D:\COURSE_PROJECT\Image\trash.png��6   5"      5#      �� 5$   
   $��0��6   
�������$��40(�64   $��Center=�6B   $��Center=�6]   $��1��6z     Raiting#���  6�   �� 5%   
   $ 
Horizontal=�6   $��Center=�6.   $��Center=�6I   $��1��6f   .+�5&      �� -   5        #��[  5&      $)��# Количество партий ��6=   6[   �� 5'      -   5        #��[  5'      $'��! Количество побед ��6=   6Z   5(      � 5)   
   $��2��6   
 � ColumnDefinitions
 5*      �� 5+      �� 5,      $��5* �6#   �� 5-       5/      �� 50      $��* �6    �� 51      $��7* �6    .+�53      � $��0��6   $��1��6    .+�54      �� $��5,0,5,0q�6   $	��560��6.   $ 
Horizontal=�6:   .+�55      �� $��30(�6   $
��Left=�6*   
�������$	��200��6^   $��Ник��6j   $��0��6x   �� 56      $��30(�6   $��Center=�6*   
�������$	��240��6^   $��Партий��6j   $��1��6{   �� 57      $��30(�6   $��Right=�6*   
�������$	��110��6^   $��
Побед��6j   $��2��6z   58      59      &   System.Windows.Controls.DataGrid  5:      -   5          Name$ RaitGrid��5:         AutoGenerateColumns .  $��5,0,5,40q�6E   $	��310��6W   $	��560��6d   
�������$��1��6�   $��1��6�      
IsReadOnly .    HeadersVisibility$
 None=�6�   $��2q�6�      Columns 5;      0  *System.Windows.Controls.DataGridTextColumn  5<      ,  &System.Windows.Controls.DataGridColumn   Header$ NickName��6)      Width5  /System.Windows.Controls.DataGridLengthConverter$	 200 6Y      FontSize$ 20Q�6m   1  +System.Windows.Controls.DataGridBoundColumn   Binding 6;   �� *
NickName+6m     5=      $ 
AmountPart��6)   $	 240 6_   $ 20Q�6m    6=   �� *AmountParties+6m     5>      $ 	WinsCount��6)   $	 110 6Z   $ 20Q�6m    6<   �� *	WinsCount+6m   5@      �� 5A      -   5         ��Name$ DelBox��5A      $��1��6&   $��1��64   $��20(�6D   $��Input to delete��6R   $��45��6i   $��	40,0,40,5q�6u   $��Bottom=�6�   5B      5C      5D      