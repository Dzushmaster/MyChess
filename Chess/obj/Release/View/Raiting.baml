   M S B A M L   `   `   `  ���� @  <Chess, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null'clr-namespace:Chess.View
Chess.View      Chess.View.Raiting   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     @d2http://schemas.microsoft.com/expression/blend/2008     *localclr-namespace:Chess.View       N� Title$  Raiting�� � 	Resources  �� 
TargetType   ButtonWithText �� Property �� Value  ButtonWithImage��%�   &	        &	 M     �� " ��.���  � ��$ 30(���  � ��$ 5q���  � ��$ 0q��� " ��.���  � ��$ 3q���  � ��$ 0q�.��� 
���   � � ShowGridLines .  � RowDefinitions �� $
��1.2* ��� $��1* ��� $��6* �.+��� -    ��Name$ Return��$
��Home��#��[ $
��Left=�$��Center=�����  �� Path$ 
SelectPage�.���� $&�� D:\COURSE_PROJECT\Image\Left.png���� 	 �� Orientation$	 
Horizontal=�$��Right=�$��Center=�.+��� #��[ ���� 
 �� ElementName$
 Return��$ ActualHeight�.���� $%��D:\COURSE_PROJECT\Image\Add.png���� #��[ ���� $
 Return��$ ActualHeight�.���� $'��!D:\COURSE_PROJECT\Image\trash.png���� $��0��
�������$��40(�$��Center=�$��Center=�$��1��  Raiting#���  �� $	 
Horizontal=�$��Center=�$��Center=�$��1��.+��� #��[  $��Points���� #��[  $��Number of parties���� #��[  $��%wins��� $��2�� .  � ColumnDefinitions �� �� $��5* ��� .+��� -    ��Name$ StackPan��$��5q�$��1��
�������