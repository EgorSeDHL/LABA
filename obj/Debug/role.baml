   M S B A M L   `   `   `  ����A  =5 prac, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null!clr-namespace:_5_prac_5_prac  5   	       _5_prac.role   5   	   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   'localclr-namespace:_5_prac     5   	     � Title$
  role��5   	   $	��450��6   $	��800��6#   .��5	      �  � RowDefinitions 5
   
   �� 5      $	��77* �6   �� 5      $
��283* �6   �� 5      $	��90* �6    � ColumnDefinitions 5   
   �� 5      �� 5      �� 5      .+�5   
   &   System.Windows.Controls.DataGrid  -   5          Name$ 
roles_grid��5         SelectionMode$ Extended=�6'   $��2��6k   $��10,10,10,10q�6   $��2��6�   6�   �� 5   
   -   5         ��Name$ update_button��5      $��Изменить��6(   $��	10,0,10,0q�6;   $��2��6N   $��Center=�6[   6v   �� 5   
   -   5        $ create_button��5      $��1��6(   $��Создать��68   $��	10,0,10,0q�6J   $��2��6]   $��Center=�6j   6�   �� 5   
   -   5        $ delete_button��5      $��2��6(   $��Удалить��68   $��	10,0,10,0q�6J   $��2��6]   $��Center=�6j   6�   �� 5   
   -   5         ��Name$ 
roles_text��5      $��2��6&   $��10q�66    �� TextWrapping$
 Wrap=�6B   $��Bottom=�6V   �� 5   
   $��2��6   $��Center=�6$   $��10q�6A   $
��Wrap=�6M   $��Название роли��6a   $��19(�6v   $	��Top=�6�   �� 5   
   -   5        $
 back��5      $��2��6   $��Назад!!!!!��6/   $��Stretch=�6D   $��10q�6b   $��Stretch=�6n   $��1��6�   6�   5      5      